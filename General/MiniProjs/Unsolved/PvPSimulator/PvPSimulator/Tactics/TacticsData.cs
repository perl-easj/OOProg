using System.Collections.Generic;

namespace PvPSimulator.Tactics
{
    /// <summary>
    /// Class which stores a Dictionary of available battle tactics.
    /// A battle tactic can be retrieved via a tactics type.
    /// </summary>
    public class TacticsData
    {
        #region Instance fields
        private Dictionary<TacticsType, ITacticsInfo> _tacticsData; 
        #endregion

        #region Constructor
        public TacticsData()
        {
            _tacticsData = new Dictionary<TacticsType, ITacticsInfo>();
            _tacticsData.Add(TacticsType.Neutral, new TacticsInfo(TacticsType.Neutral, 1.0, 1.0));
            _tacticsData.Add(TacticsType.Offensive, new TacticsInfo(TacticsType.Offensive, 1.2, 0.85));
            _tacticsData.Add(TacticsType.Defensive, new TacticsInfo(TacticsType.Defensive, 0.8, 1.3));
        }
        #endregion

        #region Methods
        public ITacticsInfo GeTacticsInfo(TacticsType type)
        {
            return _tacticsData.ContainsKey(type) ? _tacticsData[type] : null;
        }

        public double AttackFactor(TacticsType type)
        {
            return _tacticsData.ContainsKey(type) ? _tacticsData[type].AttackFactor : 1.0;
        }

        public double DefenseFactor(TacticsType type)
        {
            return _tacticsData.ContainsKey(type) ? _tacticsData[type].DefenseFactor : 1.0;
        } 
        #endregion
    }
}