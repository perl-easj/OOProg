using System;
using System.Collections.Generic;

namespace Algorithms01
{
    public class MyBackPackAlgorithm : BackPackAlgorithm
    {
        public MyBackPackAlgorithm(List<BackPackItem> items, double capacity) 
            : base(items, capacity)
        {
        }

        public override void Solve(double capacityLeft)
        {
            string description = PickNextItemFromVault(capacityLeft);
            if (description != string.Empty)
            {
                BackPackItem item = TheVault.RemoveItem(description);
                TheBackPack.AddItem(item);
                Solve(TheBackPack.WeightCapacityLeft);
            }
        }

        private string PickNextItemFromVault(double capacityLeft)
        {
            double bestRatio = 0;
            BackPackItem bestItem = null;

            foreach (var item in TheVault.Items)
            {
                if (item.Weight <= capacityLeft)
                {
                    double ratio = item.Value / item.Weight;

                    if (ratio > bestRatio)
                    {
                        bestRatio = ratio;
                        bestItem = item;
                    }
                }
            }

            return (bestItem != null) ? bestItem.Description : string.Empty;
        }
    }
}