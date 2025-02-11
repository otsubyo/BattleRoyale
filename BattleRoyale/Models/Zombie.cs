namespace BattleRoyale.Models
{
    // Zombie (mort‑vivant) : jet de défense toujours égal à 0 ; ne peut pas contre‑attaquer.
    // Insensible à la douleur.
    class Zombie : Character
    {
        public Zombie()
        {
            Name = "Zombie";
            BaseAttack = 100;
            BaseDefense = 0;
            BaseInitiative = 20;
            Damages = 60;
            MaximumLife = 1000;
            CurrentLife = MaximumLife;
            TotalAttackNumber = 1;
            CurrentAttackNumber = 1;
        }

        public override void BeginRound()
        {
            // Les morts‑vivants ne sont pas affectés par la douleur.
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
            Console.WriteLine($"{Name} a une défense toujours égale à 0.");
            return 0;
        }
    }
}