namespace NaiveRPG
{
    public class Bear
    {
        public int HealthPoints { get; private set; }
        public int GoldOwned { get; }
        public Boots BootsToLoot { get; }
        public bool Dead
        {
            get { return HealthPoints <= 0; }
        }

        public Bear()
        {
            HealthPoints = 12;
            GoldOwned = 17;
            BootsToLoot = new Boots("A pair of plain, brown", 28);
        }

        public void ReceiveDamage(int damagePoints)
        {
            HealthPoints = HealthPoints - damagePoints;
        }
    }
}