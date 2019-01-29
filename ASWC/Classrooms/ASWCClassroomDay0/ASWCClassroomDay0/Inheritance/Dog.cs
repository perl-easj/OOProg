using System;

namespace ASWCClassroomDay0.Inheritance
{
    public class Dog : Animal
    {
        public bool CanHunt { get; set; }

        public Dog(int age, bool canHunt) 
            : base(age)
        {
            CanHunt = canHunt;
        }

        public void Sound()
        {
            Console.WriteLine("Vov");
        }

        public override string ToString()
        {
            return $"A {(CanHunt ? "hunting" : "domestic")} dog which is {Age} years old";
        }
    }
}