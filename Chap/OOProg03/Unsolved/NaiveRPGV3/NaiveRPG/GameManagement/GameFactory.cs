using NaiveRPG.Interfaces;

namespace NaiveRPG.GameManagement
{
    /// <summary>
    /// The GameFactory - which is a Singleton - holds references
    /// to factories for Items and Participants. This is mainly to
    /// avoid dragging factory object references through the code.
    /// </summary>
    public class GameFactory
    {
        private static GameFactory _instance;

        public IArmorFactory ArmorFactory { get; set; }
        public IWeaponFactory WeaponFactory { get; set; }
        public IParticipantFactory ParticipantFactory { get; set; }

        public static GameFactory Instance()
        {
            return _instance ?? (_instance = new GameFactory());
        }

        private GameFactory()
        {
        }
    }
}