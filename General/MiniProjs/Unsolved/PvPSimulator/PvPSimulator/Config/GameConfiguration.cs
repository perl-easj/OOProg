using System;
using PvPSimulator.PlayerFactory;

namespace PvPSimulator.Config
{
    /// <summary>
    /// Manages the current configuration of the game.
    /// The class is a Singleton.
    /// </summary>
    public class GameConfiguration
    {
        #region Instance fields        
        private IPlayerFactory _factory;
        #endregion

        #region Singleton implementation
        private static GameConfiguration _instance;
        public static GameConfiguration Instance
        {
            get
            {
                _instance = _instance ?? new GameConfiguration();
                return _instance;
            }
        }
        #endregion

        #region Constructor
        private GameConfiguration()
        {
            _factory = null;
        }
        #endregion

        #region Properties
        public IPlayerFactory Factory
        {
            get
            {
                if (_factory == null)
                {
                    throw new NullReferenceException("Factory has not been set!");
                }
                return _factory;
            }

            set { _factory = value; }
        } 
        #endregion
    }
}