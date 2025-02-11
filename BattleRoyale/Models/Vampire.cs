// Vampire (mort‑vivant) : se soigne de la moitié des dégâts qu’il inflige.
// Insensible à la douleur.
using BattleRoyale.Models;
using System.Xml.Linq;

class Vampire : Character
{
    public Vampire()
    {
        Name = "Vampire";
        BaseAttack = 100;
        BaseDefense = 100;
        BaseInitiative = 120;
        Damages = 50;
        MaximumLife = 300;
        CurrentLife = MaximumLife;
        TotalAttackNumber = 2;
        CurrentAttackNumber = 2;
    }

    public override void BeginRound()
    {
        // Le Vampire est insensible à la douleur.
        CurrentAttackNumber = TotalAttackNumber;
    }

    public override int RollInitiative(Random rand)
    {
        int roll = rand.Next(1, 101);
        int result = BaseInitiative + roll;
        Console.WriteLine($"{Name} a {BaseInitiative} d'initiative et obtient {roll} aux dés. {Name} a une initiative de {result} pour ce tour.");
        return result;
    }

    public override int RollAttack(Random rand)
    {
        int roll = rand.Next(1, 101);
        int result = BaseAttack + roll;
        Console.WriteLine($"{Name} a {BaseAttack} d'attaque et obtient {roll} aux dés. {Name} attaque avec {result} d'attaque.");
        return result;
    }

    public override int RollDefense(Random rand)
    {
        int roll = rand.Next(1, 101);
        int result = BaseDefense + roll;
        Console.WriteLine($"{Name} a {BaseDefense} de défense et obtient {roll} aux dés. {Name} se défend avec une valeur de {result}.");
        return result;
    }

    public void Heal(int damageInflicted)
    {
        int heal = damageInflicted / 2;
        CurrentLife += heal;
        if (CurrentLife > MaximumLife) CurrentLife = MaximumLife;
        Console.WriteLine($"{Name} se soigne de {heal} points de vie en buvant son sang.");
    }
}