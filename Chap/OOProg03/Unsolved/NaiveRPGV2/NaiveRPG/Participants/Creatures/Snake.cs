namespace NaiveRPG.Participants.Creatures
{
    public class Snake : CreatureBase
    {
        public const int MaxInitialHelthPoints = 40;
        public const int MaxDamage = 10;

        public Snake() : base(MaxInitialHelthPoints, MaxDamage)
        {
        }
    }
}