using System;
using System.Collections;
using System.Collections.Generic;

namespace ASWCClassroomDay3
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
            State.Add(NPCStateTypes.aggressive, 50);
            State.Add(NPCStateTypes.fear, 50);
            State.Add(NPCStateTypes.gullible, 50);
            State.Add(NPCStateTypes.hungry, 50);
            State.Add(NPCStateTypes.rested, 50);
        }

        public int this[NPCStateTypes stateType]
        {
            get { return State[stateType]; }
            set { State[stateType] = value; }
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