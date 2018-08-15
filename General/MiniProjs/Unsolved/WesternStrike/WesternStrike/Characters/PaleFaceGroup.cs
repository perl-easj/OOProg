using System.Collections.Generic;
using WesternStrike.Combat;

namespace WesternStrike.Characters
{
    public class PaleFaceGroup
    {
        private List<PaleFace> _paleFaces;

        public PaleFaceGroup(List<PaleFace> paleFace)
        {
            _paleFaces = paleFace;
        }

        public bool Dead
        {
            get
            {
                foreach (PaleFace member in _paleFaces)
                {
                    if (!member.Dead)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public List<PaleFace> PaleFacesAlive
        {
            get
            {
                List<PaleFace> alive = new List<PaleFace>();
                foreach (PaleFace member in _paleFaces)
                {
                    if (!member.Dead)
                    {
                        alive.Add(member);
                    }
                }

                return alive;
            }
        }

        public PaleFace SelectRandomPaleFace()
        {
            return PaleFacesAlive.Count == 0 ? null : PaleFacesAlive[NumberGenerator.Next(0, PaleFacesAlive.Count - 1)];
        }

        public void LogSurvivors()
        {
            foreach (PaleFace member in PaleFacesAlive)
            {
                CombatLog.Save(member.Name + " survived with " + member.HitPoints + " hit points left");
            }
        }
    }
}