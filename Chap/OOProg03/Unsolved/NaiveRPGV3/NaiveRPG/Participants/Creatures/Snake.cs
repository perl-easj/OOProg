namespace NaiveRPG.Participants.Creatures
{
    public class Snake : CreatureBase
    {
        public const int MaxInitialHelthPoints = 40;
        public const int MeleeMaxDamage = 10;

        public Snake() : base(MaxInitialHelthPoints, MeleeMaxDamage)
        {
        }
    }
}