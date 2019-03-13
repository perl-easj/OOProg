namespace SOLID.SingleResp
{
    public class AnimalLibrary : IAnimalLibrary
    {
        public bool FoodAround(string food)
        {
            return true;
        }

        public void Sleep()
        {
            // General code for sleeping...
        }
    }
}