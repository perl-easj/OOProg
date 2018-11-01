namespace NaiveRPG.Participants.Creatures
{
    /// <summary>
    /// Base class for creature-like participants.
    /// These participants always start with at most
    /// three items and no gold.
    /// </summary>
    public class CreatureBase : ParticipantBase
    {
        public const int MaxInitialItems = 3;

        public CreatureBase(int maxInitialHealthPoints, double maxDamage) 
            : base("", maxInitialHealthPoints, 0, MaxInitialItems, maxDamage)
        {
        }

        public override string Name
        {
            get { return GetType().Name; }
        }
    }
}