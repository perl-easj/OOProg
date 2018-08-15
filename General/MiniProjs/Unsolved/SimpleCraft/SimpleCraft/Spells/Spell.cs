namespace SimpleCraft.Spells
{
    public class Spell
    {
        #region Instance fields
        private string _description;
        private string _shortName;
        private int _duration;
        private double _damagePerSecond;
        private double _range;
        #endregion

        #region Constructor
        public Spell(
            string description,
            string shortName,
            int duration,
            double damagePerSecond,
            double range)
        {
            _description = description;
            _shortName = shortName;
            _duration = duration;
            _damagePerSecond = damagePerSecond;
            _range = range;
        }
        #endregion

        #region Properties
        public string Description
        {
            get { return _description; }
        }

        public string ShortName
        {
            get { return _shortName; }
        }

        public int Duration
        {
            get { return _duration; }
        }

        public double DamagePerSecond
        {
            get { return _damagePerSecond; }
        }

        public double Range
        {
            get { return _range; }
        }
        #endregion
    }
}