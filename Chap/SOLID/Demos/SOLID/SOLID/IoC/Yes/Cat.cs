namespace SOLID.IoC.Yes
{
    public class Cat : Animal
    {
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
            Sleep();
        }

        private void HuntMice() { }

        private void Sleep() { }
    }
}