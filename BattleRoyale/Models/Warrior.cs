namespace BattleRoyale.Models;

// Guerrier : quand affecté par la douleur, ne peut pas attaquer ce round.
using BattleRoyale.Models;
using System.Xml.Linq;

class Guerrier : Character
{
    public Guerrier()
    {
        Name = "Guerrier";
        BaseAttack = 100;
        BaseDefense = 100;
        BaseInitiative = 50;
        Damages = 100;
        MaximumLife = 200;
        CurrentLife = MaximumLife;
        TotalAttackNumber = 2;
        CurrentAttackNumber = 2;
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