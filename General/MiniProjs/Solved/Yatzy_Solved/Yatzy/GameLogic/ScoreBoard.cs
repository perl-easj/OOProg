using System;
using System.Collections.Generic;

namespace Yatzy.GameLogic
{
    /// <summary>
    /// First steps towards a ScoreBoard class.
    /// </summary>
    public class ScoreBoard
    {
        private Dictionary<string, ScoreBoardEntry> _scoreBoardEntries;

        public ScoreBoard()
        {
            _scoreBoardEntries = new Dictionary<string, ScoreBoardEntry>();
        }

        public int TotalScore
        {
            get
            {
                int score = 0;

                foreach (var entry in _scoreBoardEntries.Values)
                {
                    if (entry.State == ScoreBoardEntry.EntryState.Used)
                    {
                        score = score + entry.Score;
                    }
                }

                return score;
            }
        }

        public void AddEntry(ScoreBoardEntry entry)
        {
            if (_scoreBoardEntries.ContainsKey(entry.ID))
            {
                throw new ArgumentException("Entry already added");
            }

            _scoreBoardEntries.Add(entry.ID, entry);
        }

        public void SetScore(string id, int score)
        {
            if (!_scoreBoardEntries.ContainsKey(id))
            {
                throw new ArgumentException("No such entry");
            }

            ScoreBoardEntry entry = _scoreBoardEntries[id];

            if (entry.State != ScoreBoardEntry.EntryState.NotUsed)
            {
                throw new ArgumentException("Entry already used");
            }

            entry.Score = score;
        }
    }
}