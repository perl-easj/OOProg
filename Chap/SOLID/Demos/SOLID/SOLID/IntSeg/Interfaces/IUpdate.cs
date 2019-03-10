namespace SOLID.IntSeg.Interfaces
{
    public interface IUpdate<in T>
    {
        void Update(int key, T obj);
    }
}