using System.Collections.Generic;
using System.Linq;

namespace RPGDemo19NOV.Model.Catalog
{
    public class CharacterCatalog
    {
        private RPGDBContext _context;

        public CharacterCatalog()
        {
            _context = new RPGDBContext();
        }

        public List<Character> All
        {
            get { return _context.Characters.ToList(); }
        }

        public void Create(Character obj)
        {
            _context.Characters.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Character obj = _context.Characters.Find(id);
            if (obj != null)
            {
                _context.Characters.Remove(obj);
                _context.SaveChanges();
            }
        }

        public Character Read(int id)
        {
            return _context.Characters.Find(id);
        }
    }
}