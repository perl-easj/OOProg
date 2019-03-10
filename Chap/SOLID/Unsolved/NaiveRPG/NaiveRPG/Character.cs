namespace NaiveRPG
{
    public class Character
    {
        public string Name { get; }
        public int GoldOwned { get; set; }
        public Sword SwordOwned { get; set; }
        public Shield ShieldOwned { get; set; }
        public Boots BootsOwned { get; set; }

        public Character(string name)
        {
            Name = name;
            GoldOwned = 0;
            SwordOwned = null;
            ShieldOwned = null;
            BootsOwned = null;
        }
    }
}