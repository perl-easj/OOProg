namespace RandomizedSelection
{
    public class SelecteeImpl<T> : ISelectee<T>
    {
        public T Selectee { get; }
        public double Probability { get; }

        public SelecteeImpl(T selectee, double probability)
        {
            Selectee = selectee;
            Probability = probability;
        }

        public override string ToString()
        {
            return $"{Selectee.ToString()}, prob. {Probability:F3}";
        }
    }
}