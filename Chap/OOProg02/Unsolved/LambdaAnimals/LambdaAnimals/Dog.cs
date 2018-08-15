namespace LambdaAnimals
{
    public class Dog
    {
        public Dog(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{Name} weighs {Weight} kg.";
        }
    }
}