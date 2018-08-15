using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy.GameLogic
{
    /// <summary>
    /// First steps towards a Game class.
    /// </summary>
    public class Game
    {
        private Dictionary<string, Player> _players;
        private string _currentPlayer;

        public Game()
        {
            _players = new Dictionary<string, Player>();
            _currentPlayer = null;
        }

        public string CurrentPlayer
        {
            get { return _currentPlayer; }
        }

        public void AddPlayer(string playerName)
        {
            if (_players.ContainsKey(playerName))
            {
                throw new ArgumentException("Entry already added");
            }

            _players.Add(playerName, new Player(playerName));
        }

        public void Start()
        {
            if (_players.Count == 0)
            {
                throw new ArgumentException("Cannot start a game with zero players");
            }

            _currentPlayer = _players.Keys.ToList()[0];
        }
    }
}