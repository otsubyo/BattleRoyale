// Goule (mort‑vivant) : c’est un charognard. Contrairement aux autres morts‑vivants, la Goule est sensible à la douleur.
// On utilise donc la méthode BeginRound héritée de Character.
using BattleRoyale.Models;
using System.Xml.Linq;

class Goule : Character
{
    public Goule()
    {
        Name = "Goule";
        BaseAttack = 50;
        BaseDefense = 80;
        BaseInitiative = 120;
        Damages = 30;
        MaximumLife = 250;
        CurrentLife = MaximumLife;
        TotalAttackNumber = 5;
        CurrentAttackNumber = 5;
    }

    // La Goule ne surcharge pas BeginRound, car elle reste sensible à la douleur (elle pourra perdre sa capacité d’attaquer en cas de dégâts importants).

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