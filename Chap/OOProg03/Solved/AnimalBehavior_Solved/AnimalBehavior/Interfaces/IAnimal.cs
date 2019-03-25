namespace AnimalBehavior.Interfaces
{
    /// <summary>
    /// Defines an interface for a small set of
    /// features we require all animals to possess.
    /// </summary>
    public interface IAnimal : IAnimalBehavior
    {
        /// <summary>
        /// Returns a string describing the animal, like "Cat" or "Old Dog".
        /// </summary>
        string WhatAmI { get; }

        /// <summary>
        /// Returns/sets the current state of the animal.
        /// </summary>
        AnimalState CurrentState { get; set; }

        /// <summary>
        /// After calling this method, the animal should act according
        /// to the given IAnimalBehavior implementation, whenever it
        /// is in the same state as the given state.
        /// </summary>
        void SetBehavior(AnimalState state, IAnimalBehavior behavior);
    }
}