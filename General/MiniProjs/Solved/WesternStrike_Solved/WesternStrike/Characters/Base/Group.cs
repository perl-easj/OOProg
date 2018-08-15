using System.Collections.Generic;
using WesternStrike.Combat;

namespace WesternStrike.Characters.Base
{
    public class Group<T> where T : Character
    {
        #region Instance fields
        private string _id;
        private List<T> _members;
        #endregion

        #region Constructor
        public Group(string id)
        {
            _members = new List<T>();
            _id = id;
        }
        #endregion

        #region Properties
        public bool Dead
        {
            get
            {
                foreach (T member in _members)
                {
                    if (!member.Dead)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public List<T> MembersAlive
        {
            get
            {
                List<T> alive = new List<T>();
                foreach (T member in _members)
                {
                    if (!member.Dead)
                    {
                        alive.Add(member);
                    }
                }

                return alive;
            }
        }

        public string ID
        {
            get { return _id; }
        }
        #endregion

        #region Group member methods (public)
        public void AddMember(T member)
        {
            _members.Add(member);
        }

        public T SelectRandomMember()
        {
            return MembersAlive.Count == 0 ? null : MembersAlive[NumberGenerator.Next(0, MembersAlive.Count - 1)];
        }
        #endregion

        #region Other methods
        public void LogSurvivors()
        {
            foreach (T member in MembersAlive)
            {
                CombatLog.Save($"{member.Name} survived with {member.HitPoints:F2} hit points left.");
            }
        } 
        #endregion
    }
}