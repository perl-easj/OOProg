using FOOrrestGump.Adapters.Interfaces;

namespace FOOrrestGump.Adapters.Implementation
{
    /// <summary>
    /// Minimal implementation of the IAdapter interface.
    /// </summary>
    /// <typeparam name="T">Type of item being adapted (i.e. the "adaptee").</typeparam>
    public class AdapterBase<T> : IAdapter<T>
    {
        private T _adaptee;

        public AdapterBase(T adaptee)
        {
            _adaptee = adaptee;
        }

        public T Adaptee
        {
            get { return _adaptee; }
        }
    }
}