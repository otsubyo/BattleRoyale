// Liche (mort‑vivant) : inflige des dégâts impies.
// Insensible à la douleur.
using BattleRoyale.Models;
using System.Xml.Linq;

class Liche : Character
{
    public Liche()
    {
        Name = "Liche";
        BaseAttack = 75;
        BaseDefense = 125;
        BaseInitiative = 80;
        Damages = 50; // inflige des dégâts impies
        MaximumLife = 125;
        CurrentLife = MaximumLife;
        TotalAttackNumber = 3;
        CurrentAttackNumber = 3;
    }

    public override void BeginRound()
    {
        // La Liche est un mort‑vivant insensible à la douleur.
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
}