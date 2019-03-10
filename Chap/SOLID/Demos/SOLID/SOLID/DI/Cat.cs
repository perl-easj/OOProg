namespace SOLID.DI
{
    public class Cat : Animal
    {
        public Cat(IWorld theWorld) : base(theWorld)
        {
        }

        protected override string PreferredFood()
        {
            return null;
        }

        protected override void GetFood()
        {
        }

        protected override void Idle()
        {
        }
    }
}