namespace NaiveRPG.Participants.Creatures
{
    public class Bear : CreatureBase
    {
        public const int MaxInitialHelthPoints = 70;
        public const int MeleeMaxDamage = 25;

        public Bear() : base(MaxInitialHelthPoints, MeleeMaxDamage)
        {
        }
    }
}