using System;
using System.Collections.Generic;
using PvPSimulator.Players;
using PvPSimulator.Tactics;

namespace PvPSimulator.PlayerFactory
{
    /// <summary>
    /// Implementation of IPlayerFactory interface. 
    /// Generates two players in a randomised fashion, within 
    /// certain limits w.r.t. hit points and base damage.
    /// </summary>
    public class RandomisedPlayerFactory : IPlayerFactory
    {
        public const int ScalingFactor = 6000;

        #region Instance fields
        private static Random _generator = new Random(Guid.NewGuid().GetHashCode());
        private List<string> _names;
        private List<string> _adjectives;
        private List<string> _types;
        private TacticsData _tacticsData;
        #endregion

        #region Constructor
        public RandomisedPlayerFactory()
        {
            _names = new List<string>
            {
                "Arthur",
                "Balon",
                "Calas",
                "Devon",
                "Elias",
                "Francis",
                "Gilbert",
                "Holbert",
                "Ivar",
                "Jokkum",
                "Karl",
                "Loris",
                "Moheim",
                "Nazar"
            };

            _adjectives = new List<string>
            {
                "Great",
                "Bold",
                "Brave",
                "Kind",
                "Brute",
                "Wise",
                "Scorned",
                "Feared",
                "Grand",
                "Seer",
                "Cunning",
                "Sly",
                "Blessed",
                "Ruler"
            };

            _types = new List<string> {"Warrior", "Knight", "Wizard", "Paladin"};

            _tacticsData = new TacticsData();
        }
        #endregion

        #region Methods
        public IPlayer CreatePlayerA()
        {
            return GeneratePlayer();
        }

        public IPlayer CreatePlayerB()
        {
            return GeneratePlayer();
        }

        private IPlayer GeneratePlayer()
        {
            string name = GeneratePlayerName();
            string type = GeneratePlayerType();
            int hp = GenerateHitPoints();
            int bd = GenerateBaseDamage(hp);

            return new Player(name, type, hp, bd, _tacticsData.GeTacticsInfo(TacticsType.Offensive));
        }

        private string GeneratePlayerType()
        {
            return _types[_generator.Next(_types.Count)];
        }

        private string GeneratePlayerName()
        {
            int nameIndex = _generator.Next(_names.Count);
            int adjIndex = _generator.Next(_adjectives.Count);
            return $"{_names[nameIndex]} the {_adjectives[adjIndex]}";
        }

        private int GenerateHitPoints()
        {
            return _generator.Next(ScalingFactor / 60, ScalingFactor / 20);
        }

        private int GenerateBaseDamage(int hitPoints)
        {
            return ScalingFactor / hitPoints;
        } 
        #endregion
    }
}