using AnimalBehavior.Interfaces;

namespace AnimalBehavior.Animals
{
    /// <summary>
    /// This class just extends the base implementation with a
    /// couple of useful constructors. Behaviors can be provided
    /// individually, or by a factory object.
    /// </summary>
    public class AnimalStandard : AnimalBase
    {
        public AnimalStandard(
            string whatAmI,
            AnimalState initialState,
            IAnimalBehavior aggressiveBehavior,
            IAnimalBehavior fearfulBehavior,
            IAnimalBehavior idleBehavior)
            : base(whatAmI, initialState)
        {
            SetBehavior(AnimalState.aggressive, aggressiveBehavior);
            SetBehavior(AnimalState.fearful, fearfulBehavior);
            SetBehavior(AnimalState.idle, idleBehavior);
        }

        public AnimalStandard(
            string whatAmI,
            AnimalState initialState, 
            IAnimalBehaviorFactory fac)
            : base(whatAmI, initialState)
        {
            SetBehavior(AnimalState.aggressive, fac.CreateAggressiveBehavior());
            SetBehavior(AnimalState.fearful, fac.CreateFearfulBehavior());
            SetBehavior(AnimalState.idle, fac.CreateIdleBehavior());
        }
    }
}