namespace NaiveRPG.Participants
{
    /// <summary>
    /// Characters also have a Level, but are otherwise
    /// just as any other paritcipant.
    /// </summary>
    public class Character : ParticipantBase
    {
        public const int MaxInitialHelthPoints = 1000;
        public const int MaxInitialGold = 100;
        public const int MaxInitialArmor = 3;
        public const int MaxInitialWeapons = 3;
        public const int MeleeMaxDamage = 50;

        public int Level { get; private set; }

        public Character(string name) 
            : base(name, 
                MaxInitialHelthPoints, 
                MaxInitialGold, 
                MaxInitialArmor,
                MaxInitialWeapons,
                MeleeMaxDamage)
        {
            Level = 1;
        }

        public void LevelUp()
        {
            Level++;
        }
    }
}