using System;
using System.Collections.Generic;
using BackPacking.Containers;
using BackPacking.Item;

namespace BackPacking.Algorithms
{
    /// <summary>
    /// This class contains a very naive solver implementation
    /// </summary>
    public class BackPackingSolverStupid : BackPackingSolverBase
    {
        public BackPackingSolverStupid(List<BackPackItem> items, double capacity)
            : base(items, capacity)
        {
        }

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
        /// This method just returns the first item in the Vault, if
        ///   1) Any items are left at all, and
        ///   2) The weight of the item does not exceed the given limit.
        /// Yes, this is a pretty stupid approach...
        /// </summary>
        /// <returns>
        /// Identifier for the next item (String.Empty if no item found)
        /// </returns>
        private string PickNextItemFromVault(ItemVault theItemVault, double weightLimit)
        {
            return (theItemVault.Items.Count > 0 && theItemVault.Items[0].Weight <= weightLimit)
                ? theItemVault.Items[0].Description
                : String.Empty;
        }
    }
}