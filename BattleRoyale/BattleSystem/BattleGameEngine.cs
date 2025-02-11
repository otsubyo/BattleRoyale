using System;
using System.Collections.Generic;

namespace BattleRoyale.Models
{
    public class BattleGameEngine
    {
        List<Character> characters;
        Random rand;
        string gameMode; // "1" pour Duel, "2" pour Battle Royale

        public BattleGameEngine(List<Character> characters, string mode)
        {
            this.characters = characters;
            this.gameMode = mode;
            rand = new Random(); // Utilisation d'une graine variable pour des combats différents
        }

        public void StartBattle()
        {
            Console.WriteLine("----- Debut du combat -----");
            int round = 1;
            while (AliveCharacters().Count > 1)
            {
                Console.WriteLine($"---------- Round {round} ----------");

                // Préparation : chaque personnage se remet en état pour le round
                foreach (var c in AliveCharacters())
                    c.BeginRound();

                // Chaque personnage effectue son jet d'initiative et on détermine l'ordre de passage
                Dictionary<Character, int> initiatives = new Dictionary<Character, int>();
                foreach (var c in AliveCharacters())
                {
                    initiatives[c] = c.RollInitiative(rand);
                }
                List<Character> order = new List<Character>(AliveCharacters());
                order.Sort((a, b) => initiatives[b].CompareTo(initiatives[a]));

                // Pour chaque attaquant dans l'ordre déterminé
                foreach (var attacker in order)
                {
                    // Si l'attaquant n'est plus vivant, on passe
                    if (!attacker.IsAlive)
                        continue;

                    // Tant que l'attaquant dispose d'attaques ce round
                    while (attacker.CurrentAttackNumber > 0)
                    {
                        // Vérification à chaque attaque : s'il est mort, on sort de la boucle
                        if (!attacker.IsAlive)
                            break;

                        // Récupération de la liste des cibles potentielles (personnages vivants autres que l'attaquant)
                        List<Character> potentialTargets = AliveCharacters().FindAll(c => c != attacker);
                        if (potentialTargets.Count == 0)
                            break;

                        // Choix d'une cible aléatoirement
                        Character target = potentialTargets[rand.Next(potentialTargets.Count)];

                        int attackRoll = attacker.RollAttack(rand);
                        Console.WriteLine($"{attacker.Name} attaque {target.Name} avec {attackRoll} d'attaque et {attacker.Damages} de dégâts.");
                        int defenseRoll = target.RollDefense(rand);
                        int marginAttack = attackRoll - defenseRoll;
                        if (marginAttack > 0)
                        {
                            int damage = marginAttack * attacker.Damages / 100;
                            Console.WriteLine($"{marginAttack}x{attacker.Damages}/100 = {damage} => {target.Name} subit {damage} points de dégâts.");
                            target.CurrentLife -= damage;
                            if (!target.IsAlive)
                            {
                                Console.WriteLine($"{target.Name} est mort.");
                                HandleCorpse(target);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{target.Name} réussit sa défense.");
                            // Si le défenseur peut contre-attaquer (et n'est pas un Zombie ni l'attaquant Kamikaze)
                            if (target.CurrentAttackNumber > 0 && !(target is Zombie) && !(attacker is Kamikaze))
                            {
                                int bonus = -marginAttack;
                                Console.WriteLine($"{target.Name} a un bonus de contre-attaque de {bonus}.");
                                int counterAttackRoll = target.RollAttack(rand) + bonus;
                                Console.WriteLine($"{target.Name} contre-attaque {attacker.Name} avec {counterAttackRoll} d'attaque et {target.Damages} de dégâts.");
                                int attackerDefRoll = attacker.RollDefense(rand);
                                int counterMargin = counterAttackRoll - attackerDefRoll;
                                if (counterMargin > 0)
                                {
                                    int counterDamage = counterMargin * target.Damages / 100;
                                    if (target is Gardien)
                                    {
                                        counterDamage *= 2;
                                        Console.WriteLine("Le bonus de contre-attaque de Gardien est doublé.");
                                    }
                                    Console.WriteLine($"{counterMargin}x{target.Damages}/100 = {counterDamage} => {attacker.Name} subit {counterDamage} points de dégâts.");
                                    attacker.CurrentLife -= counterDamage;
                                    if (!attacker.IsAlive)
                                    {
                                        Console.WriteLine($"{attacker.Name} est mort.");
                                        HandleCorpse(attacker);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"{attacker.Name} réussit sa défense contre la contre-attaque.");
                                }
                                target.CurrentAttackNumber--; // Le défenseur consomme une attaque pour la contre-attaque.
                            }
                        }
                        attacker.CurrentAttackNumber--; // L'attaquant consomme une attaque.
                    }
                }

                Console.WriteLine($"---------- Fin du round ----------");
                Console.WriteLine();
                round++;
                Console.WriteLine("Appuyez sur une touche pour lancer le prochain round.");
                Console.ReadKey();
            }

            Console.WriteLine("Le combat est terminé.");
            if (AliveCharacters().Count == 1)
            {
                if (gameMode == "1")
                    Console.WriteLine($"{AliveCharacters()[0].Name} remporte le duel");
                else
                    Console.WriteLine($"{AliveCharacters()[0].Name} remporte le battle royale");
            }
        }

        List<Character> AliveCharacters()
        {
            return characters.FindAll(c => c.IsAlive);
        }

        // Lorsqu'un personnage meurt, les charognards (Zombie et Goule) récupèrent entre 50 et 100 points de vie.
        void HandleCorpse(Character dead)
        {
            foreach (var c in AliveCharacters())
            {
                if (c is Zombie || c is Goule)
                {
                    int heal = rand.Next(50, 101);
                    c.CurrentLife += heal;
                    if (c.CurrentLife > c.MaximumLife) c.CurrentLife = c.MaximumLife;
                    Console.WriteLine($"{c.Name} mange le cadavre de {dead.Name} et récupère {heal} points de vie.");
                }
            }
        }
    }
}
