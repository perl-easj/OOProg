using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDBApp.Configuration
{
    public class AppConfig
    {
        public static void DoConfig()
        {
            using (var db = new GameDBContext())
            {
                int noOfCharacters = db.Characters.Count();
                int noOfWeapons = db.Weapons.Count();
                int noOfJewels = db.Jewels.Count();

                int x = 0;

            }
        }
    }
}
