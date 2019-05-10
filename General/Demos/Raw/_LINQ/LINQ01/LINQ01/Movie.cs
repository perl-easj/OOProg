using System.Collections.Generic;

namespace LINQ01
{
    public class Movie
    {
        private string _title;
        private int _year;
        private int _durationInMins;
        private string _studioName;
        private List<Actor> _actors;

        public Movie(string title, int year, int durationInMins, string studioName)
        {
            _title = title;
            _year = year;
            _durationInMins = durationInMins;
            _studioName = studioName;
            _actors = new List<Actor>();
        }

        public string Title
        {
            get { return _title; }
        }

        public int Year
        {
            get { return _year; }
        }

        public int DurationInMins
        {
            get { return _durationInMins; }
        }

        public string StudioName
        {
            get { return _studioName; }
        }

        public List<Actor> Actors
        {
            get { return _actors; }
        }

        public override string ToString()
        {
            return $"{Title}, released in {Year} ({DurationInMins} mins), by {StudioName}";
        }
    }
}