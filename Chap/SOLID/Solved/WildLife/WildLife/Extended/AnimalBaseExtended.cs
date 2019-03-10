using System;
using System.Collections.Generic;
using System.Linq;
using WildLife.Common;

namespace WildLife.Extended
{
    public class AnimalBaseExtended : AnimalBase
    {
        private Dictionary<int, AnimalBehavior> _behavior;

        public AnimalBaseExtended(AnimalKind kind, AnimalGender gender) : base(kind, gender)
        {
            _behavior = new Dictionary<int, AnimalBehavior>();
        }

        public void AddBehavior(int priority, Func<bool> condition, Action behavior)
        {
            _behavior[priority] = new AnimalBehavior(condition, behavior);
        }

        public override void Act()
        {
            bool acted = false;
            List<int> priorityIndices = _behavior.Keys.OrderBy(m => m).ToList();

            for (int i = 0; i < priorityIndices.Count && !acted; i++)
            {
                acted = _behavior[priorityIndices[i]].DoBehavior();
            }

            if (!acted)
            {
                Idle();
            }
        }
    }
}