using System;

namespace SimpleCraft.Spells
{
    public class SpellCast
    {
        #region Instance fields and Events
        private Spell _spell;
        private int _x;
        private int _y;
        private int _time;
        private int _spellCastIndex;

        public event Action<string, int, double> DealDamage;
        #endregion

        #region Constructor
        public SpellCast(Spell spell, int x, int y, int time, int spellCastIndex)
        {
            _spell = spell;
            _x = x;
            _y = y;
            _time = time;
            _spellCastIndex = spellCastIndex;

            DealDamage = null;
        }
        #endregion

        #region Properties
        public double DPS
        {
            get { return _spell.DamagePerSecond; }
        }

        public double Range
        {
            get { return _spell.Range; }
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public int StartTime
        {
            get { return _time; }
        }

        public int EndTime
        {
            get { return _time + _spell.Duration; }
        }

        public string Description
        {
            get { return _spell.Description; }
        }

        public int SpellCastIndex
        {
            get { return _spellCastIndex; }
        }
        #endregion

        #region Methods
        public void OnTick(int tick)
        {
            DealDamage?.Invoke(Description, SpellCastIndex, DPS);
        } 
        #endregion
    }
}