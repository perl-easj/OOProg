namespace SOLID.NoIoC
{
    public class Cat : Animal
    {
        public override void Act()
        {
            if (FoodAround("Mouse"))
            {
                HuntMice();
            }
            else
            {
                Sleep();
            }
        }

        private void HuntMice() { }

        private void Sleep() { }
    }
}