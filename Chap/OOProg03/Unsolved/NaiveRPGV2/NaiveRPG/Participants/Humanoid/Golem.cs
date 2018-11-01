namespace NaiveRPG.Participants.Humanoid
{
    public class Golem : HumanoidBase
    {
        public const int MaxInitialHelthPoints = 200;
        public const int MaxDamage = 80;

        public Golem(string name) : base(name, MaxInitialHelthPoints, MaxDamage)
        {
        }
    }
}