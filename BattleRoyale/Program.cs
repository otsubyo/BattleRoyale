using System;
using System.Collections.Generic;
using BattleRoyale.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string choixMode;
        do
        {
            Console.WriteLine("Choisissez le mode de combat : 1 - Duel, 2 - Battle Royale");
            choixMode = Console.ReadLine();
            if (choixMode != "1" && choixMode != "2")
            {
                Console.WriteLine("Erreur : Veuillez saisir 1 ou 2.");
            }
        } while (choixMode != "1" && choixMode != "2");

        List<Character> characters = new List<Character>();

        if (choixMode == "1")
        {
            // Mode duel : on demande à l'utilisateur de choisir les deux combattants.
            Console.WriteLine("Choisissez le premier personnage pour le duel :");
            Console.WriteLine("1 - Guerrier");
            Console.WriteLine("2 - Berseker");
            Console.WriteLine("3 - Gardien");
            Console.WriteLine("4 - Zombie");
            Console.WriteLine("5 - Robot");
            Console.WriteLine("6 - Liche");
            Console.WriteLine("7 - Goule");
            Console.WriteLine("8 - Vampire");
            Console.WriteLine("9 - Kamikaze");
            Console.WriteLine("10 - Prêtre");

            string choix1 = Console.ReadLine();
            Character personnage1 = GetCharacter(choix1);

            Console.WriteLine("Choisissez le deuxième personnage pour le duel :");
            string choix2 = Console.ReadLine();
            Character personnage2 = GetCharacter(choix2);

            // Si la même classe est sélectionnée, on différencie les personnages en ajoutant " 1" et " 2"
            if (personnage1.GetType() == personnage2.GetType())
            {
                personnage1.Name += " 1";
                personnage2.Name += " 2";
            }

            characters.Add(personnage1);
            characters.Add(personnage2);
        }
        else
        {
            // Mode battle royale : on instancie tous les types
            characters.Add(new Berseker());
            characters.Add(new Gardien());
            characters.Add(new Goule());
            characters.Add(new Liche());
            characters.Add(new Robot());
            characters.Add(new Guerrier());
            characters.Add(new Zombie());
            characters.Add(new Vampire());
            characters.Add(new Kamikaze());
            characters.Add(new Pretre());
        }

        BattleGameEngine game = new BattleGameEngine(characters, choixMode);
        game.StartBattle();

        Console.WriteLine("Appuyez sur une touche pour fermer cette fenêtre.");
        Console.ReadKey();
    }

    static Character GetCharacter(string choix)
    {
        switch (choix)
        {
            case "1":
                return new Guerrier();
            case "2":
                return new Berseker();
            case "3":
                return new Gardien();
            case "4":
                return new Zombie();
            case "5":
                return new Robot();
            case "6":
                return new Liche();
            case "7":
                return new Goule();
            case "8":
                return new Vampire();
            case "9":
                return new Kamikaze();
            case "10":
                return new Pretre();
            default:
                Console.WriteLine("Choix invalide, on instancie un Guerrier par défaut.");
                return new Guerrier();
        }
    }
}
