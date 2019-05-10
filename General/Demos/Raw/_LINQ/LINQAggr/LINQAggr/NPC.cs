using System;
using System.Collections;
using System.Collections.Generic;

namespace LINQAggr
{
    public class NPC : IEnumerable<Tuple<NPC.NPCStateTypes, int>>
    {
        public enum NPCStateTypes
        {
            hungry, rested, aggressive, fear, gullible
        }

        private Dictionary<NPCStateTypes, int> State;

        public NPC()
        {
            State = new Dictionary<NPCStateTypes, int>();
            SetDefaultValues();
        }

        public int this[NPCStateTypes stateType]
        {
            get{ return State[stateType]; }
            set
            {
                if (ValueIsValid(value))
                {
                    State[stateType] = value;
                }
                else
                {
                    throw new ArgumentException("...");
                }
            }
        }

        private bool ValueIsValid(int value)
        {
            return value < 1000;
        }

        public int Hungry
        {
            get { return State[NPCStateTypes.hungry]; }
            set { State[NPCStateTypes.hungry] = value; }
        }

        public void SetStateValue(NPCStateTypes stateType, int value)
        {
            State[stateType] = value;
        }

        public int GetStateValue(NPCStateTypes stateType)
        {
            return State[stateType];
        }

        private void SetDefaultValues()
        {
        }

        public IEnumerator<Tuple<NPCStateTypes, int>> GetEnumerator()
        {
            foreach (var keyValuePair in State)
            {
                NPCStateTypes stateType = keyValuePair.Key;
                int val = keyValuePair.Value;
                yield return new Tuple<NPCStateTypes, int>(stateType, val);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}