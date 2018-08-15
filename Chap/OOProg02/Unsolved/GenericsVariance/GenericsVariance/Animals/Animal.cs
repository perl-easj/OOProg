namespace GenericsVariance.Animals
{
    public abstract class Animal
    {
        private string name;

        protected Animal(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public abstract string Sound();
    }
}