using System.Collections.Generic;

namespace RolePlayV21
{
    public class BeastArmy
    {
        private List<Beast> _army;

        public BeastArmy()
        {
            _army = new List<Beast>();
        }

        /// <summary>
        /// Add one Beast to the army 
        /// </summary>
        public void AddBeast(Beast aBeast)
        {
            _army.Add(aBeast);
        }

        /// <summary>
        /// Dead is defined as: All members of the army must be dead
        /// </summary>
        public bool Dead
        {
            get
            {
                return false; // TODO - implement as specified
            } 
        }

        /// <summary>
        /// Returns the names of all Beasts that are currently alive
        /// </summary>
        public List<string> BeastsAlive
        {
            get
            {
                List<string> alive = new List<string>();

                // TODO - implement as specified

                return alive;
            }
        }

        /// <summary>
        /// DealDamage is defined as: 
        /// The total damage dealt by all
        /// non-dead members of the army
        /// </summary>
        public int DealDamage()
        {
            int totalDamage = 0;

            // TODO - implement as specified

            return totalDamage;
        }

        /// <summary>
        /// ReceiveDamage is defined as: 
        /// The first non-dead beast in the list 
        /// receives all of the damage
        /// </summary>
        public void ReceiveDamage(int damage)
        {
            // TODO - implement as specified
        }
    }
}
