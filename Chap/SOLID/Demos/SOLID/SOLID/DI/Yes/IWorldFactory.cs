namespace SOLID.DI.Yes
{
    public interface IWorldFactory
    {
        IWorld Create(bool manyOrFew);
    }
}