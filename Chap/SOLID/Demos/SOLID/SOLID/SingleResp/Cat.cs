namespace SOLID.SingleResp
{
    public class Cat : AnimalBehavior
    {
        public Cat(IAnimalLibrary anAnimalLib)
            : base(anAnimalLib)
        {
        }

        protected override string PreferredFood()
        {
            return "Mouse";
        }

        protected override void GetFood()
        {
            HuntMice();
        }

        protected override void Idle()
        {
            AnimalLib.Sleep();
        }

        private void HuntMice() { }
    }
}