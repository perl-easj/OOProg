using System.Collections.Generic;
using WesternStrike.Combat;

namespace WesternStrike.Characters
{
    public class IndianGroup
    {
        private List<Indian> _indians;

        public IndianGroup(List<Indian> indians)
        {
            _indians = indians;
        }

        public bool Dead
        {
            get
            {
                foreach (Indian member in _indians)
                {
                    if (!member.Dead)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public List<Indian> IndiansAlive
        {
            get
            {
                List<Indian> alive = new List<Indian>();
                foreach (Indian member in _indians)
                {
                    if (!member.Dead)
                    {
                        alive.Add(member);
                    }
                }

                return alive;
            }
        }

        public Indian SelectRandomIndian()
        {
            return IndiansAlive.Count == 0 ? null : IndiansAlive[NumberGenerator.Next(0, IndiansAlive.Count - 1)];
        }

        public void LogSurvivors()
        {
            foreach (Indian member in IndiansAlive)
            {
                CombatLog.Save(member.Name + " survived with " + member.HitPoints + " hit points left");
            }
        }
    }
}