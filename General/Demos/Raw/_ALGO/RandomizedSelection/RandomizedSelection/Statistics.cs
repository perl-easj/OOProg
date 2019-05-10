using System.Collections.Generic;
using System.Linq;

namespace RandomizedSelection
{
    public class Statistics<T>
    {
        private Dictionary<T, int> _registrations;

        public Statistics(List<T> selecteeList)
        {
            _registrations = new Dictionary<T, int>();
            foreach (T item in selecteeList)
            {
                _registrations.Add(item, 0);
            }
        }

        public void Register(T item)
        {
            if (_registrations.ContainsKey(item))
            {
                _registrations[item]++;
            }
        }

        public Dictionary<T, int> Registrations
        {
            get { return _registrations; }
        }

        public int TotalNoOfRegistrations
        {
            get { return _registrations.Select(s => s.Value).Sum(); }
        }

        public Dictionary<T, double> Frequencies
        {
            get
            {
                Dictionary<T, double> freq = new Dictionary<T, double>();
                foreach (var entry in _registrations)
                {
                    freq.Add(entry.Key, (entry.Value * 1.0) / (TotalNoOfRegistrations * 1.0));
                }

                return freq;
            }
        }
    }
}