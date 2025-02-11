namespace BattleRoyale.Models;

// Prêtre : cible en priorité les morts‑vivants, inflige des dégâts sacrés et se soigne de 10% de MaximumLife au début de son tour.
using BattleRoyale.Models;
using System.Xml.Linq;

class Pretre : Character
{
    public Pretre()
    {
        Name = "Priest";
        BaseAttack = 75;
        BaseDefense = 125;
        BaseInitiative = 50;
        Damages = 50;
        MaximumLife = 150;
        CurrentLife = MaximumLife;
        TotalAttackNumber = 1;
        CurrentAttackNumber = 1;
    }
    public override void BeginRound()
    {
        int heal = MaximumLife * 10 / 100;
        CurrentLife += heal;
        if (CurrentLife > MaximumLife) CurrentLife = MaximumLife;
        Console.WriteLine($"{Name} se soigne de {heal} points de vie au début de son tour.");
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