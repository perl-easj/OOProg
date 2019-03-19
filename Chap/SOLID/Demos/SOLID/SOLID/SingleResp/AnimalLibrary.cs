namespace SOLID.SingleResp
{
    public class AnimalLibrary : IAnimalLibrary
    {
        private IWorld World { get; }

        public AnimalLibrary(IWorld world)
        {
            World = world;
        }

        public bool FoodAround(string food)
        {
            return World.IsAnimalClose(food);
        }

        public void Sleep()
        {
            // General code for sleeping...
        }
    }
}