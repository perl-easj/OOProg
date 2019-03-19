namespace SOLID.DI.Yes
{
    public abstract class Animal : IAnimal
    {
        private IWorld TheWorld { get; }

        protected Animal(IWorld theWorld)
        {
            TheWorld = theWorld;
        }

        public void Act()
        {
            if (FoodAround(PreferredFood()))
            {
                GetFood();
            }
            else
            {
                Idle();
            }
        }

        private bool FoodAround(string preferredFood)
        {
            return TheWorld.IsAnimalClose(preferredFood);
        }

        protected abstract string PreferredFood();

        protected abstract void GetFood();

        protected abstract void Idle();
    }
}