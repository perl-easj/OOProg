namespace SOLID.Liskov.Yes
{
    public class Siamese : Cat
    {
        public Siamese() : base(new Tiger())
        {
            
        }

        public override string Description
        {
            get { return "HUAEAEAEAEAEEHHH....."; }
        }
    }
}