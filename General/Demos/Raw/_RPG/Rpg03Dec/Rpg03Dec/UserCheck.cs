using System.Collections.Generic;
using System.Linq;

namespace Rpg03Dec
{
    public class UserCheck
    {
        private List<User> _users;

        public UserCheck()
        {
            _users = new List<User>();
        }

        public bool OkUser(string name, string pwd)
        {
            List<User> matchingUsers = _users.Where(u => u.Name == name).ToList();

            if (matchingUsers.Count == 0)
            {
                return false;
            }

            User aUser = matchingUsers[0];

            return aUser.Password == pwd;
        }
    }
}