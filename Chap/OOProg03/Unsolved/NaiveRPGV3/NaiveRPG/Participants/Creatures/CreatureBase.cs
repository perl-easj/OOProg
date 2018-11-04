namespace NaiveRPG.Participants.Creatures
{
    /// <summary>
    /// Base class for creature-like participants.
    /// These participants always start with at most
    /// three items and no gold.
    /// </summary>
    public class CreatureBase : ParticipantBase
    {
        public const int MaxInitialArmor = 2;
        public const int MaxInitialWeapon = 0;

        public CreatureBase(int maxInitialHealthPoints, double maxDamage) 
            : base("", maxInitialHealthPoints, 0, MaxInitialArmor, MaxInitialWeapon, maxDamage)
        {
        }

        public override string Name
        {
            get { return GetType().Name; }
        }
    }
}