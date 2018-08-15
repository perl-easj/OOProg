using System;
using SimpleCraft.GUI;

namespace SimpleCraft.Characters
{
    public class Character
    {
        #region Instance fields
        private string _name;
        private double _hitPoints;
        private int _x;
        private int _y;

        private int _characterIndex;
        private static int _noOfCharactersCreated;
        #endregion

        #region Constructor
        public Character(string name, double hitPoints, int x, int y)
        {
            _name = name;
            _hitPoints = hitPoints;
            _x = x;
            _y = y;

            _characterIndex = ++_noOfCharactersCreated;
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
        }

        public double HitPoints
        {
            get { return _hitPoints; }
        }

        public bool Dead
        {
            get { return (_hitPoints <= 0); }
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }
        #endregion

        #region Methods
        public void PrintCharacterSummary(int tick)
        {
            SimpleGUI.SetCursorPosition(0, _characterIndex);
            Console.WriteLine(Dead ?
                  $"{Name} has died.                                                         "
                : $"{Name} at ({X},{Y}) has {HitPoints} hit points left");
        }

        public void ReceiveSpellDamage(string description, int index, double points)
        {
            if (_hitPoints > 0)
            {
                _hitPoints = _hitPoints - points;
            }

            SimpleGUI.SetCursorPosition(index, _characterIndex);
            Console.WriteLine($"  {Name} received {points} damage from the spell {description}");
        }

        public void SpellCastEnded(int index)
        {
            SimpleGUI.DeleteLine(index, _characterIndex);
        } 
        #endregion
    }
}