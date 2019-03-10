namespace SOLID.SingleResp
{
    public abstract class AnimalBehavior : IAnimalBehavior
    {
        protected IAnimalLibrary AnimalLib { get; set; }

        protected AnimalBehavior(IAnimalLibrary anAnimalLib)
        {
            AnimalLib = anAnimalLib;
        }

        public void Act()
        {
            if (AnimalLib.FoodAround(PreferredFood()))
            {
                GetFood();
            }
            else
            {
                Idle();
            }
        }

        protected abstract string PreferredFood();

        protected abstract void GetFood();

        protected abstract void Idle();
    }
}