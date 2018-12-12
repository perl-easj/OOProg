namespace Part3
{
    public class Wizard
    {
        public string Name { get; }
        public double HealthPoints { get; set; }
        public double MagicPower { get; set; }
        public int WandLevel { get; set; }

        public Wizard(string name, double healthPoints, double magicPower, int wandLevel)
        {
            Name = name;
            HealthPoints = healthPoints;
            MagicPower = magicPower;
            WandLevel = wandLevel;
        }

        public double DealDamageWithWand()
        {
            return WandLevel * MagicPower;
        }

        public override string ToString()
        {
            return $"A Wizard named {Name}, with {HealthPoints} HP. " +
                   $"Deals {DealDamageWithWand():F1} damage";
        }
    }
}