namespace SOLID.IntSeg.Interfaces
{
    public interface ICreate<in T>
    {
        void Create(int key, T obj);
    }
}