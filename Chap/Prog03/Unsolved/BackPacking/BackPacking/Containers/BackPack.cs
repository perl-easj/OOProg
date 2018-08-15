using System;
using BackPacking.Item;

namespace BackPacking.Containers
{
    /// <summary>
    /// This class represents a backpack with limited weight capacity.
    /// A number of BackPackItem objects can be put into the backpack.
    /// </summary>
    public class BackPack : BackPackItemContainer
    {
        private double _weightCapacity;

        public BackPack(double weightCapacity) : base("Backpack")
        {
            _weightCapacity = weightCapacity;
        }

        #region Properties
        /// <summary>
        /// Returns the weight capacity of the backpack when empty
        /// </summary>
        public double WeightCapacity
        {
            get { return _weightCapacity; }
        }

        /// <summary>
        /// Returns the weight of the items currently in the backpack
        /// </summary>
        public double WeightCapacityUsed
        {
            get
            {
                double capacityUsed = 0;
                foreach (var item in Items)
                {
                    capacityUsed += item.Weight;
                }

                return capacityUsed;
            }
        }

        /// <summary>
        /// Returns the remaining weight capacity of the backpack
        /// </summary>
        public double WeightCapacityLeft
        {
            get { return (WeightCapacity - WeightCapacityUsed); }
        }

        /// <summary>
        /// Returns the total value of the set of BackPackItem 
        /// objects currently in the backpack.
        /// </summary>
        public int TotalValueOfItems
        {
            get
            {
                int totalValue = 0;
                foreach (var item in Items)
                {
                    totalValue += item.Value;
                }

                return totalValue;
            }
        }
        #endregion

        #region Methods (base class overrides)
        /// <summary>
        /// Extends the base version with a check for weight capacity
        /// </summary>
        public override void AddItem(BackPackItem item)
        {
            if (item.Weight > WeightCapacityLeft)
            {
                throw new ArgumentException("Oops, you over-stuffed the BackPack!!");
            }

            base.AddItem(item);
        }

        /// <summary>
        /// Extends the base version with printout of item value
        /// </summary>
        public override void PrintContent()
        {
            base.PrintContent();
            Console.WriteLine($"Total weight : {WeightCapacityUsed} kg.");
            Console.WriteLine($"Total value  : {TotalValueOfItems}");

            Console.WriteLine();
        }
        #endregion
    }
}