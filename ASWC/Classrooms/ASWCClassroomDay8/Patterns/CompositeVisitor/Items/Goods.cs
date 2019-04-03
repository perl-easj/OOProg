using System.Collections.Generic;
using System.Linq;
using Patterns.CompositeVisitor.Interfaces;

namespace Patterns.CompositeVisitor.Items
{
    public class Goods : ICompositable
    {
        private List<ICompositable> _items;

        public Goods(List<ICompositable> items)
        {
            _items = items;
        }

        public double Price
        {
            get { return _items.Sum(i => i.Price); }
        }

        public double Weight
        {
            get { return _items.Sum(i => i.Weight); }
        }

        public string WhatAmI { get { return "Composite"; } }
    }
}