using System;
using System.Diagnostics;

namespace Fight1v1
{
    /// <summary>
    /// This class contains the general algorithm for a 1v1 fight,
    /// implemented in the method Fight.
    /// </summary>
    public abstract class Fight1v1Manager : IFight1v1Manager
    {
        #region Instance fields
        private Player _playerA;
        private Player _playerB;
        private int _noOfFights;
        private Stopwatch _watch;
        #endregion

        #region Constructor
        protected Fight1v1Manager(Player playerA, Player playerB, int noOfFights)
        {
            _playerA = playerA;
            _playerB = playerB;
            _noOfFights = noOfFights;
            _watch = new Stopwatch();
        }
        #endregion

        #region Properties
        protected Player PlayerA
        {
            get { return _playerA; }
        }

        protected Player PlayerB
        {
            get { return _playerB; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Main fight management method: Conduct a number of 1v1 fights
        /// between player A and player B, and keep track of statistics.
        /// </summary>
        public void Fight()
        {
            int noOfWinsA = 0;
            int noOfWinsB = 0;

            _watch.Restart();
            for (int i = 0; i < _noOfFights; i++)
            {
                SingleFight();
                noOfWinsA += _playerA.Dead ? 0 : 1;
                noOfWinsB += _playerB.Dead ? 0 : 1;
            }
            _watch.Stop();

            Report(noOfWinsA, noOfWinsB);
        }

        /// <summary>
        /// Conduct a single 1v1 fight between player A and player B.
        /// </summary>
        private void SingleFight()
        {
            // Reset both players to original state
            _playerA.Reset();
            _playerB.Reset();

            // Fight until the death!
            while (!_playerA.Dead && !_playerB.Dead)
            {
                ExchangeBlows(_playerA, _playerB);
            }
        }

        /// <summary>
        /// This method should implement the specific strategy for
        /// how player A and player B exchange one round of blows
        /// (i.e. A hits B, and B hits A, but the specific order
        /// should be implemented in a derived class).
        /// </summary>
        protected abstract void ExchangeBlows(Player playerA, Player playerB);

        /// <summary>
        /// Report statistics for the conducted fights.
        /// </summary>
        private void Report(int noOfWinsA, int noOfWinsB)
        {
            Console.WriteLine($"Result of simulation ({_noOfFights} fights, took {_watch.ElapsedMilliseconds} milliSecs)");
            Console.WriteLine($"Player A won {noOfWinsA} fights ({(noOfWinsA * 100.0 / _noOfFights):F1}) %");
            Console.WriteLine($"Player B won {noOfWinsB} fights ({(noOfWinsB * 100.0 / _noOfFights):F1}) %");
            Console.WriteLine();
        }
        #endregion
    }
}