using System.Collections.Generic;
using System.Linq;

namespace Part2
{
    public class HunterRepository
    {
        private Dictionary<string, Hunter> _hunters;

        public HunterRepository()
        {
            _hunters = new Dictionary<string, Hunter>();
        }

        public List<Hunter> AllHunters
        {
            get { return _hunters.Values.ToList(); }
        }

        public void Insert(Hunter aHunter)
        {
            if (!_hunters.ContainsKey(aHunter.Name))
            {
                _hunters.Add(aHunter.Name, aHunter);
            }
        }

        public Hunter Read(string name)
        {
            return _hunters.ContainsKey(name) ? _hunters[name] : null;
        }

        public void Remove(Hunter aHunter)
        {
            _hunters.Remove(aHunter.Name);
        }
    }
}