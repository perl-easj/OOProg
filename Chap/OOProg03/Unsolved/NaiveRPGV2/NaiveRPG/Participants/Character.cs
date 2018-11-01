using System;

namespace NaiveRPG.Participants
{
    /// <summary>
    /// Characters also have a Level, but are otherwise
    /// just as any other paritcipant.
    /// </summary>
    public class Character : ParticipantBase
    {
        public const int MaxInitialHelthPoints = 500;
        public const int MaxInitialGold = 100;
        public const int MaxInitialItems = 5;
        public const int MaxDamage = 50;

        public int Level { get; private set; }

        public Character(string name) 
            : base(name, MaxInitialHelthPoints, MaxInitialGold, MaxInitialItems, MaxDamage)
        {
            Level = 1;
        }

        public void LevelUp()
        {
            Level++;
        }
    }
}