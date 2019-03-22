namespace NaiveRPG
{
    public class Troll
    {
        public string Name { get; }
        public int HealthPoints { get; private set; }
        public int GoldOwned { get; }
        public Sword SwordToLoot { get; }
        public Shield ShieldToLoot { get; }
        public bool Dead
        {
            get { return HealthPoints <= 0; }
        }

        public Troll(string name)
        {
            Name = name;
            HealthPoints = 23;
            GoldOwned = 35;
            SwordToLoot = new Sword("A plain", 25);
            ShieldToLoot = null;
        }

        public void ReceiveDamage(int damagePoints)
        {
            HealthPoints = HealthPoints - damagePoints;
        }
    }
}