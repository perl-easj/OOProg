using System;

namespace Yatzy.GameLogic
{
    /// <summary>
    /// This class represents a single entry in a scoreboard
    /// </summary>
    public class ScoreBoardEntry
    {
        /// <summary>
        /// A scoreboard entry can be 
        /// NotUsed: Player has not used this entry yet
        /// Used: Player has noted a score in this entry
        /// Scratched: Player chose to score zero in this entry
        /// </summary>
        public enum EntryState
        {
            NotUsed,
            Used,
            Scratched
        }

        private string _id;
        private int _score;

        public ScoreBoardEntry(string id)
        {
            _id = id;
            _score = 0;
        }

        public string ID
        {
            get { return _id; }
        }

        public int Score
        {
            get
            {
                return (_score < 0 ? 0 : Score);
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Score must be positive");
                }

                _score = value;
            }
        }

        /// <summary>
        /// State can be determined from the score, since a score
        /// of -1 indicates that the entry is scratched
        /// </summary>
        public EntryState State
        {
            get
            {
                if (_score > 0)
                {
                    return EntryState.Used;
                }
                else if (_score == 0)
                {
                    return EntryState.NotUsed;
                }
                else
                {
                    return EntryState.Scratched;
                }
            }
        }

        /// <summary>
        /// If a player decides to Scratch an entry, the score
        /// is set to -1.
        /// </summary>
        public void Scratch()
        {
            if (_score == 0)
            {
                _score = -1;
            }
            else
            {
                throw new ArgumentException("Cannot scratch a used entry");
            }
        }
    }
}