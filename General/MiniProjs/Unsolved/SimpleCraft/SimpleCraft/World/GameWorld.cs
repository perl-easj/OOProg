using System;
using System.Collections.Generic;
using SimpleCraft.Characters;
using SimpleCraft.GUI;
using SimpleCraft.Spells;

namespace SimpleCraft.World
{
    public class GameWorld
    {
        #region Instance fields
        private List<Character> _characters;
        private SpellCastManager _scManager;
        private GameClock _clock;
        #endregion

        #region Constructor
        public GameWorld(List<Character> characters, int ticks)
        {
            _characters = characters;
            _clock = new GameClock();

            // Attach the PrintCharacterSummary to the Tick event
            // for the game clock, such that a summary is printed
            // at every tick.
            foreach (Character ch in characters)
            {
                _clock.Tick += ch.PrintCharacterSummary;
            }

            // Attach the ManageSpellCasts to the Tick event
            // for the game clock, such that spell casts are
            // "managed" at every tick.
            _scManager = new SpellCastManager(this);
            _clock.Tick += _scManager.ManageSpellCasts;

            // Game clock time is printed at every tick
            _clock.Tick += PrintGameClock;
            _clock.Start(ticks);
        }
        #endregion

        #region Properties
        public List<Character> Characters
        {
            get { return _characters; }
        }

        public GameClock Clock
        {
            get { return _clock; }
        }

        public SpellCastManager SCManager
        {
            get { return _scManager; }
        }
        #endregion

        #region Methods
        public void PrintGameClock(int tick)
        {
            SimpleGUI.SetCursorForTime();
            Console.WriteLine($"Game Time: {tick}");
        } 
        #endregion
    }
}