using System;

namespace RolePlayV20
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            NumberGenerator theNumberGenerator = new NumberGenerator();
            BattleLog theLog = new BattleLog();

            Hero theHero = new Hero(theNumberGenerator, theLog, 100, 10, 30);
            Beast theBeast = new Beast(theNumberGenerator, theLog, 90, 10, 25);

            // While both battle participants are alive (i.e. not dead)
            while (!theHero.Dead && !theBeast.Dead)
            {
                // Hero hits Beast
                int damageByHero = theHero.DealDamage();
                theBeast.ReceiveDamage(damageByHero);

                // If Beast is still alive: Beast hits Hero
                if (!theBeast.Dead)
                {
                    int damageByBeast = theBeast.DealDamage();
                    theHero.ReceiveDamage(damageByBeast);
                }
            }

            theLog.PrintLog();

            // The LAST line of code should be ABOVE this line
        }
    }
}