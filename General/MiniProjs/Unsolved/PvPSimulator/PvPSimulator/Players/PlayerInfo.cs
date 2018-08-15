namespace PvPSimulator.Players
{
    /// <summary>
    /// Straightforward implementation of the IPlayerInfo interface.
    /// </summary>
    public class PlayerInfo : IPlayerInfo
    {
        #region Instance fields
        private string _name;
        private string _type;
        private double _initialPoints;
        private double _baseDamage;
        #endregion

        #region Constructor
        public PlayerInfo(string name, string type, double initialHitPoints, double baseDamage)
        {
            _name = name;
            _type = type;
            _initialPoints = initialHitPoints;
            _baseDamage = baseDamage;
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
        }

        public string Type
        {
            get { return _type; }
        }

        public double InitialHitPoints
        {
            get { return _initialPoints; }
        }

        public double BaseDamage
        {
            get { return _baseDamage; }
        } 
        #endregion
    }
}