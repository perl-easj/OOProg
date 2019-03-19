using System;

namespace SOLID.Liskov.Composition
{
    public class AnimalWeightLargeImpl : AnimalWeightBase
    {
        public AnimalWeightLargeImpl(double weight = weightUndefined) : base(1, weight)
        {
        }
    }
}