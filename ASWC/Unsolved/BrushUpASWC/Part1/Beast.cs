namespace Part1
{
    public class Beast
    {
        public string Species { get; }
        public double HealthPoints { get; set; }

        public Beast(string species, double healthPoints)
        {
            Species = species;
            HealthPoints = healthPoints;
        }

        public bool Dead
        {
            get { return HealthPoints <= 0; }
        }

        public void ReceiveDamage(double damage)
        {
            HealthPoints = HealthPoints - damage;
        }
    }
}