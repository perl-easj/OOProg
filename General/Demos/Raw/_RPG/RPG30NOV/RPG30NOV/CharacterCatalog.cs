using System.Collections.Generic;
using System.Linq;
using Windows.Security.Authentication.Web.Core;

namespace RPG30NOV
{
    public class CharacterCatalog
    {
        private RPGDBContext _dbContext;

        public CharacterCatalog()
        {
            _dbContext = new RPGDBContext();
        }

        public List<Character> All
        {
            get { return _dbContext.Characters.ToList(); }
        }

        public Character Read(int id)
        {
            return _dbContext.Characters.Find(id);
        }

        public void Delete(int id)
        {
            Character aCharacter = Read(id);
            if (aCharacter != null)
            {
                _dbContext.Characters.Remove(aCharacter);
                _dbContext.SaveChanges();
            }
        }
    }
}