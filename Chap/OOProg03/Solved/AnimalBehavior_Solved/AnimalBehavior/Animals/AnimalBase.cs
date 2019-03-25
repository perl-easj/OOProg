using System;
using System.Collections.Generic;
using AnimalBehavior.Interfaces;

namespace AnimalBehavior.Animals
{
    /// <summary>
    /// Fairly straightforward implementation of IAnimal interface.
    /// Note that a Dictionary is used to map states to behaviors.
    /// </summary>
    public class AnimalBase : IAnimal
    {
        public string WhatAmI { get; }
        public AnimalState CurrentState { get; set; }
        public Dictionary<AnimalState, IAnimalBehavior> Behaviors { get; }

        public AnimalBase(string whatAmI, AnimalState initialState = AnimalState.idle)
        {
            WhatAmI = whatAmI;
            CurrentState = initialState;
            Behaviors = new Dictionary<AnimalState, IAnimalBehavior>();
        }

        /// <summary>
        /// Setting a behavior will always overwrite any existing
        /// behavior for the given state.
        /// </summary>
        public void SetBehavior(AnimalState state, IAnimalBehavior behavior)
        {
            Behaviors[state] = behavior;
        }

        /// <summary>
        /// Invoke the behavior corresponding in the current state.
        /// Throw exception if no behavior is defined for that state.
        /// </summary>
        public void Act()
        {
            if (Behaviors.ContainsKey(CurrentState))
            {
                Behaviors[CurrentState].Act();
            }
            else
            {
                throw new Exception($"No behavior defined for state {CurrentState}");
            }
        }
    }
}