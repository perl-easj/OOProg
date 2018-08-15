using System.Collections.Generic;

namespace PvPSimulator.Utility
{
    /// <summary>
    /// Class for maintaining a "battle log", 
    /// which is just a collection of strings.
    /// The class is a Singleton.
    /// </summary>
    public class BattleLog
    {
        #region Instance fields
        private List<string> _log;
        #endregion

        #region Singleton implementation
        private static BattleLog _instance;
        public static BattleLog Instance
        {
            get
            {
                _instance = _instance ?? new BattleLog();
                return _instance;
            }
        }
        #endregion

        #region Constructor
        private BattleLog()
        {
            _log = new List<string>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the entire content of the log.
        /// </summary>
        public List<string> Content
        {
            get { return _log; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Save a single new entry in the log.
        /// </summary>
        public void Save(string message)
        {
            _log.Add(message);
        }

        /// <summary>
        /// Reset the log, i.e. delete all existing content.
        /// </summary>
        public void Reset()
        {
            _log.Clear();
        } 
        #endregion
    }
}