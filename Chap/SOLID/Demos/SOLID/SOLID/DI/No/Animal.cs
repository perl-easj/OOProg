namespace SOLID.DI.No
{
    public abstract class Animal : IAnimal
    {
        private IWorld TheWorld { get; }

        protected Animal(bool manyOrFew)
        {
            if (manyOrFew)
            {
                TheWorld = new WorldManyAnimals();
            }
            else
            {
                TheWorld = new WorldFewAnimals();
            }
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