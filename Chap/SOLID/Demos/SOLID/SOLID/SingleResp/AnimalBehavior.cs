using SOLID.DI;

namespace SOLID.SingleResp
{
    public abstract class AnimalBehavior : IAnimalBehavior
    {
        private IWorld TheWorld { get; }
        protected IAnimalLibrary AnimalLib { get; set; }

        protected AnimalBehavior(IWorld theWorld, IAnimalLibrary anAnimalLib)
        {
            TheWorld = theWorld;
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