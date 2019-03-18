namespace SOLID.DI.Yes
{
    public class WorldFactoryDefault : IWorldFactory
    {
        public IWorld Create(bool manyOrFew)
        {
            if (manyOrFew)
            {
                return new WorldManyAnimals();
            }
            else
            {
                return new WorldFewAnimals();
            }
        }
    }
}