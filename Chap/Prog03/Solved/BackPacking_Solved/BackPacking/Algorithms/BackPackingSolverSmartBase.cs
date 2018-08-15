using System.Collections.Generic;
using BackPacking.Containers;
using BackPacking.Item;

namespace BackPacking.Algorithms
{
    /// <summary>
    /// This class contains a greedy algorithm for backpacking, i.e.
    /// continually pick the "best" item from the vault, until no
    /// more items can be picked.
    /// </summary>
    public abstract class BackPackingSolverSmartBase : BackPackingSolverBase
    {
        protected BackPackingSolverSmartBase(List<BackPackItem> items, double capacity) 
            : base(items, capacity)
        {
        }

        /// <summary>
        /// The solver follows these steps:
        /// 1) Select the "best" item from the Vault (see PickBestItemFromVault).
        ///    If (a description of) an item is returned, then
        ///    2) Remove the item from the Vault.
        ///    3) Add the item to the Backpack.
        ///    4) Call Solve again (the weight capacity will now be reduced).
        /// </summary>
        public override void Solve(ItemVault theItemVault, BackPack theBackPack)
        {
            string description = PickNextItemFromVault(theItemVault, theBackPack.WeightCapacityLeft);
            if (description != string.Empty)
            {
                BackPackItem item = theItemVault.RemoveItem(description);
                theBackPack.AddItem(item);
                Solve(theItemVault, theBackPack);
            }
        }

        /// <summary>
        /// This method picks the "best" item currently in the Vault.
        /// "Best" is defined as the item for which it holds that:
        ///   1) The weight of the item does not exceed the given limit.
        ///   2) No other item (for which 1) holds) has a higher 
        ///      "actual item value". The calculation of "actual item value"
        ///      is deferred to derived classes.
        /// </summary>
        /// <returns>
        /// Identifier for the "best" item (String.Empty if no item found)
        /// </returns>
        private string PickNextItemFromVault(ItemVault theItemVault, double weightLimit)
        {
            double bestValue = 0;
            BackPackItem bestItem = null;

            foreach (var item in theItemVault.Items)
            {
                if (item.Weight <= weightLimit)
                {
                    double candidateValue = ActualItemValue(item);

                    if (candidateValue > bestValue)
                    {
                        bestValue = candidateValue;
                        bestItem = item;
                    }
                }
            }

            return (bestItem != null) ? bestItem.Description : string.Empty;
        }

        /// <summary>
        /// A derived class can implement this method, to provide a 
        /// specific definition of "actual item value"
        /// </summary>
        protected abstract double ActualItemValue(BackPackItem item);
    }
}