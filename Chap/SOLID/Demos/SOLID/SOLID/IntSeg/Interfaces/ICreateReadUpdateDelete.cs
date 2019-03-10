namespace SOLID.IntSeg.Interfaces
{
    /// <summary>
    /// Full CRUD interface
    /// </summary>
    public interface ICreateReadUpdateDelete<T>
    {
        void Create(int key, T obj);
        T Read(int key);
        void Update(int key, T obj);
        void Delete(int key);
    }
}