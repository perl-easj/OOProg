namespace FOOrrestGump.Adapters.Interfaces
{
    /// <summary>
    /// General interface for any kind of Adapter class.
    /// </summary>
    /// <typeparam name="T">Type of item being adapted (i.e. the "adaptee").</typeparam>
    public interface IAdapter<out T>
    {
        T Adaptee { get; }
    }
}