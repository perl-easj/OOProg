using System;

namespace SOLID.Liskov.Composition
{
    public class AnimalWeightNormalImpl : AnimalWeightBase
    {
        public AnimalWeightNormalImpl(double weight = weightUndefined) : base(0.001, weight)
        {
        }
    }
}