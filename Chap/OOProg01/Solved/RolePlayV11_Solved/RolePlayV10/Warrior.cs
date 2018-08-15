namespace RolePlayV11
{
    public class Warrior
    {
        #region Instance fields
        private string _name;
        private int _level;
        private int _hitPoints; // Added
        #endregion

        #region Constructor
        public Warrior(string name, int hitPoints) // Added parameter
        {
            _name = name;
            _hitPoints = hitPoints; // Added
            _level = 1;
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
        }

        public int Level
        {
            get { return _level; }
        }

        public int HitPoints // Added
        {
            get { return _hitPoints; }
        }

        public bool Dead // Added
        {
            get { return _hitPoints <= 0; }
        }
        #endregion

        #region Methods
        public void LevelUp()
        {
            _level = _level + 1;
        }

        public void DecreaseHitPoints(int points) // Added
        {
            _hitPoints = _hitPoints - points;
        } 
        #endregion
    }
}