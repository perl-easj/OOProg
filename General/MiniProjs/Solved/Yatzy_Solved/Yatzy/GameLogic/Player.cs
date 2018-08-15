namespace Yatzy.GameLogic
{
    /// <summary>
    ///  Some first steps towrads a Player class
    /// </summary>
    public class Player
    {
        private string _name;
        private int _roundsPlayed;
        private ScoreBoard _scoreBoard;

        public Player(string name)
        {
            _name = name;
            _roundsPlayed = 0;
            _scoreBoard = new ScoreBoard();
        }

        public string Name
        {
            get { return _name; }
        }

        public int RoundsPlayed
        {
            get { return _roundsPlayed; }
            set { _roundsPlayed = value; }
        }
    }
}