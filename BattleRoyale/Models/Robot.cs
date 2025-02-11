namespace BattleRoyale.Models;

// Robot : pas de tirage aléatoire (toujours +50) et augmente son attaque de 50 au début de chaque round.
using BattleRoyale.Models;
using System.Xml.Linq;

class Robot : Character
{
    public Robot()
    {
        Name = "Robot";
        BaseAttack = 10;
        BaseDefense = 100;
        BaseInitiative = 50;
        Damages = 50;
        MaximumLife = 200;
        CurrentLife = MaximumLife;
        TotalAttackNumber = 1;
        CurrentAttackNumber = 1;
    }
    public override void BeginRound()
    {
        BaseAttack = (int)(BaseAttack * 1.5);
        Console.WriteLine($"L'attaque de {Name} augmente à {BaseAttack}.");
        base.BeginRound();
    }
    public override int RollInitiative(Random rand)
    {
        // Pas de tirage aléatoire : on ajoute toujours 50
        int result = BaseInitiative + 50;
        Console.WriteLine($"{Name} a {BaseInitiative} d'initiative et obtient 50 aux dés. {Name} a une initiative de {result} pour ce tour.");
        return result;
    }
    public override int RollAttack(Random rand)
    {
        int result = BaseAttack + 50;
        Console.WriteLine($"{Name} a {BaseAttack} d'attaque et obtient 50 aux dés. {Name} attaque avec {result} d'attaque.");
        return result;
    }
    public override int RollDefense(Random rand)
    {
        int result = BaseDefense + 50;
        Console.WriteLine($"{Name} a {BaseDefense} de défense et obtient 50 aux dés. {Name} se défend avec une valeur de {result}.");
        return result;
    }
}