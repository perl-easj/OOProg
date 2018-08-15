using PvPSimulator.PlayerFactory;
using PvPSimulator.Players;

namespace PvPSimulator.Config
{
    /// <summary>
    /// Handles the initial setup of the simulation. 
    /// The main responsibility is to configure the 
    /// game with a valid player factory object.
    /// The class is a Singleton.
    /// </summary>
    public class Setup
    {
        #region Singleton implementation
        private static Setup _instance;
        public static Setup Instance
        {
            get
            {
                _instance = _instance ?? new Setup();
                return _instance;
            }
        }
        #endregion

        #region Constructor
        private Setup()
        {
        }
        #endregion

        #region Methods
        public void Init()
        {
            GameConfiguration.Instance.Factory = new RandomisedPlayerFactory();
        } 
        #endregion
    }
}