namespace NaiveRPG.Participants.Creatures
{
    public class Goat : CreatureBase
    {
        public const int MaxInitialHelthPoints = 35;
        public const int MeleeMaxDamage = 20;

        public Goat() : base(MaxInitialHelthPoints, MeleeMaxDamage)
        {
        }
    }
}