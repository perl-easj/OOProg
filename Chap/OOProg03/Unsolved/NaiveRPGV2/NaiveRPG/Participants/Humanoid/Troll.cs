namespace NaiveRPG.Participants.Humanoid
{
    public class Troll : HumanoidBase
    {
        public const int MaxInitialHelthPoints = 70;
        public const int MaxDamage = 25;

        public Troll(string name) : base(name, MaxInitialHelthPoints, MaxDamage)
        {
        }
    }
}