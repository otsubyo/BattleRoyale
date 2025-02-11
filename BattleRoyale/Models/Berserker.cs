namespace BattleRoyale.Models;

// Berseker : ajoute les points de vie perdus à ses dégâts ; si CurrentLife < 50% de MaximumLife, TotalAttackNumber devient 4.
using BattleRoyale.Models;
using System.Xml.Linq;


class Berseker : Character
{
    public Berseker()
    {
        Name = "Berseker";
        BaseAttack = 100;
        BaseDefense = 100;
        BaseInitiative = 80;
        Damages = 20;
        MaximumLife = 300;
        CurrentLife = MaximumLife;
        TotalAttackNumber = 1;
        CurrentAttackNumber = 1;
    }
    public override void BeginRound()
    {
        if (CurrentLife < MaximumLife / 2)
        {
            TotalAttackNumber = 4;
        }
        base.BeginRound();
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
        int bonus = MaximumLife - CurrentLife;
        int result = BaseAttack + roll + bonus;
        Console.WriteLine($"{Name} a {BaseAttack} d'attaque, obtient {roll} aux dés et un bonus de vie perdue de {bonus}. {Name} attaque avec {result} d'attaque.");
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