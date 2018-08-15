namespace PvPSimulator.Tactics
{
    /// <summary>
    /// Straightforward implementation of the ITacticsInfo interface.
    /// </summary>
    public class TacticsInfo : ITacticsInfo
    {
        #region Instance fields
        private TacticsType _type;
        private double _attackFactor;
        private double _defenseFactor;
        #endregion

        #region Constructor
        public TacticsInfo(TacticsType type, double attackFactor, double defenseFactor)
        {
            _type = type;
            _attackFactor = attackFactor;
            _defenseFactor = defenseFactor;
        }
        #endregion

        #region Properties
        public double AttackFactor
        {
            get { return _attackFactor; }
        }

        public double DefenseFactor
        {
            get { return _defenseFactor; }
        }

        public TacticsType Type
        {
            get { return _type; }
        } 
        #endregion
    }
}
