namespace GenericsDraft01
{
    public class C<T> : ICGet<T>, ICSet<T>
    {
        private T _t;

        public T Get()
        {
            return _t;
        }

        public void Set(T t)
        {
            _t = t;
        }
    }
}