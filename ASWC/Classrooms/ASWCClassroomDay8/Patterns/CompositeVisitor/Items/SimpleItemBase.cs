using Patterns.CompositeVisitor.Interfaces;

namespace Patterns.CompositeVisitor.Items
{
    public class SimpleItemBase : ICompositable
    {
        public double Price { get; }
        public double Weight { get; }
        public string WhatAmI
        {
            get { return GetType().Name; }
        }

        public SimpleItemBase(double price, double weight)
        {
            Price = price;
            Weight = weight;
        }
    }
}