namespace RandomizedSelection
{
    public interface IRandomSelector<out T>
    {
        T Select();
    }
}