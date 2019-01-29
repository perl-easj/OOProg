using System;

namespace ASWCClassroomDay0.Inheritance
{
    public class Animal
    {
        public int Age { get; set; }

        public Animal(int age)
        {
            Age = age;
        }

        public void Sound()
        {
            Console.WriteLine("...");
        }
    }
}