namespace SOLID.IntSeg.Interfaces
{
    public interface IRead<out T>
    {
        T Read(int key);
    }
}