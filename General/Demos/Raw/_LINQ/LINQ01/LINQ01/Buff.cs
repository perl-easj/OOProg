namespace LINQ01
{
    public class Buff
    {
        public Buff(string description, double factor)
        {
            Description = description;
            Factor = factor;
        }

        public string Description { get; }
        public double Factor{ get; }
    }
}