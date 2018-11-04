namespace NaiveRPG.Participants.Creatures
{
    public class Wolf : CreatureBase
    {
        public const int MaxInitialHelthPoints = 60;
        public const int MeleeMaxDamage = 18;

        public Wolf() : base(MaxInitialHelthPoints, MeleeMaxDamage)
        {
        }
    }
}