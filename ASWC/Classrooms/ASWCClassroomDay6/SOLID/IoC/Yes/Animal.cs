namespace SOLID.IoC.Yes
{
    public abstract class Animal : IAnimal
    {
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

        private bool FoodAround(string food)
        {
            return true;
        }

        protected abstract string PreferredFood();

        protected abstract void GetFood();

        protected abstract void Idle();
    }
}