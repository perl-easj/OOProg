using System;
using System.Collections.Generic;
using SimpleCraft.Characters;
using SimpleCraft.GUI;
using SimpleCraft.World;

namespace SimpleCraft.Spells
{
    /// <summary>
    /// This class maintains the connection between the 
    /// active spell casts and the characters in the world.
    /// </summary>
    public class SpellCastManager
    {
        #region Instance fields
        private List<SpellCast> _spellCasts;
        private GameWorld _gameWorld;
        #endregion

        #region Constructor
        public SpellCastManager(GameWorld gameWorld)
        {
            _spellCasts = new List<SpellCast>();
            _gameWorld = gameWorld;
        }
        #endregion

        #region Methods
        public void AddSpellCast(string shortName, int x, int y, int time)
        {
            Spell sp = SpellBook.LookupSpell(shortName);

            if (sp != null)
            {
                SimpleGUI.SetCursorForSpellCast(_spellCasts.Count);
                Console.WriteLine($"Cast {sp.Description} at ({x},{y}) @{time}");

                SpellCast sc = new SpellCast(sp, x, y, time, _spellCasts.Count + 1);
                _gameWorld.Clock.Tick += sc.OnTick;
                _spellCasts.Add(sc);
            }
        }

        public void ManageSpellCasts(int tick)
        {
            foreach (SpellCast sc in _spellCasts)
            {
                foreach (Character ch in _gameWorld.Characters)
                {
                    if (tick == sc.StartTime && Geometry.Distance(sc.X, sc.Y, ch.X, ch.Y) < sc.Range)
                    {
                        sc.DealDamage += ch.ReceiveSpellDamage;
                    }
                    if (tick == sc.EndTime && Geometry.Distance(sc.X, sc.Y, ch.X, ch.Y) < sc.Range)
                    {
                        sc.DealDamage -= ch.ReceiveSpellDamage;
                        ch.SpellCastEnded(sc.SpellCastIndex);
                    }
                }
            }
        } 
        #endregion
    }
}