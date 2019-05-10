namespace GenericsDemo01
{
    public class Kunde : IKey<int>
    {
        public int KundeId { get; }

        public int Key
        {
            get { return KundeId; }
        }
    }
}