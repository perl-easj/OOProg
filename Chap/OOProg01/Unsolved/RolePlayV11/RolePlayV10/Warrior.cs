namespace RolePlayV11
{
    public class Warrior
    {
        #region Instance fields
        private string _name;
        private int _level;
        #endregion

        #region Constructor
        public Warrior(string name)
        {
            _name = name;
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
        #endregion

        #region Methods
        public void LevelUp()
        {
            _level = _level + 1;
        }
        #endregion
    }
}