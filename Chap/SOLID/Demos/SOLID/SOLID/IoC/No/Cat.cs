namespace SOLID.IoC.No
{
    public class Cat : Animal
    {
        // Traditional:
        // I am the Cat class, so I am solely 
        // responsible for correct implementation
        // of Cat behavior.
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