using System;

namespace FunctionsAsParameters01
{
    public class Animal
    {
        private Func<string> _animalTypeFunc;
        private Func<string> _soundFunc;

        public Animal(Func<string> animalTypeFunc, Func<string> soundFunc)
        {
            _soundFunc = soundFunc;
            _animalTypeFunc = animalTypeFunc;
        }

        public string AnimalType
        {
            get { return _animalTypeFunc(); }
        }

        public string Sound
        {
            get { return _soundFunc(); }
        }

        public override string ToString()
        {
            return "A " + AnimalType + " that says " + Sound;
        }
    }
}