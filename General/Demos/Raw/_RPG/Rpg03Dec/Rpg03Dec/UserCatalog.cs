using System.Collections.Generic;
using System.Linq;

namespace Rpg03Dec
{
    public class UserCatalog : CatalogBase<User>
    {
        public UserCatalog()
        {
            All = new List<User>();    
            All.Add(new User("Hasan", "1234"));
            All.Add(new User("Per", "aaa!!!111"));
        }

        public bool OkUser(string name, string pwd)
        {
            List<User> matchingUsers = All.Where(u => u.Name == name && u.Password == pwd).ToList();
            return matchingUsers.Count > 0;
        }
    }
}