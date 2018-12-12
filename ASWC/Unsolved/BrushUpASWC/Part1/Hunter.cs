namespace Part1
{
    public class Hunter
    {
        public string Name { get; }
        public double HealthPoints { get; set; }
        public double AimPower { get; set; }
        public int BowLevel { get; set; }

        public Hunter(string name, double healthPoints, double aimPower, int bowLevel)
        {
            Name = name;
            HealthPoints = healthPoints;
            AimPower = aimPower;
            BowLevel = bowLevel;
        }

        public double DealDamageWithBow()
        {
            return AimPower * BowLevel;
        }

        public override string ToString()
        {
            return $"A Hunter named {Name}, with {HealthPoints} HP. " +
                   $"Deals {DealDamageWithBow():F1} damage";
        }
    }
}