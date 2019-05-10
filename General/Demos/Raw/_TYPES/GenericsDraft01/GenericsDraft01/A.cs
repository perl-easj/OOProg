namespace GenericsDraft01
{
    public class A
    {
        public void Swap<T>(ref T a, ref T b) where T : class
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}