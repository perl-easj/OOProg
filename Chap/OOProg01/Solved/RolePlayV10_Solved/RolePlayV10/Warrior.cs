using System;

namespace RolePlayV10
{
    public class Warrior
    {
        #region Instance fields
        private string _name;
        private int _level; // Added 
        #endregion

        #region Constructor
        public Warrior(string name)
        {
            _name = name;
            _level = 1; // Added
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
        }

        public int Level // Added
        {
            get { return _level; }
        }
        #endregion

        #region Methods
        public void LevelUp() // Added
        {
            _level = _level + 1;
        } 
        #endregion
    }
}