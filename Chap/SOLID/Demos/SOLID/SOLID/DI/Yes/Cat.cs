namespace SOLID.DI.Yes
{
    public class Cat : Animal
    {
        public Cat(IWorld theWorld) : base(theWorld)
        {
        }

        protected override string PreferredFood()
        {
            return "Mouse";
        }

        protected override void GetFood()
        {
        }

        protected override void Idle()
        {
        }
    }
}