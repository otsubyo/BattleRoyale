namespace BattleRoyale.Models;

// Kamikaze : chaque attaque cible chaque personnage avec 50% de chance (aucune contre‑attaque possible).
using BattleRoyale.Models;
using System.Xml.Linq;

class Kamikaze : Character
{
    public Kamikaze()
    {
        Name = "Kamikaze";
        BaseAttack = 50;
        BaseDefense = 125;
        BaseInitiative = 20;
        Damages = 75;
        MaximumLife = 500;
        CurrentLife = MaximumLife;
        TotalAttackNumber = 6;
        CurrentAttackNumber = 6;
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
}
