using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms01
{
    public abstract class BackPackAlgorithm
    {
        protected ItemVault _theVault;
        protected BackPack _theBackPack;

        protected BackPackAlgorithm(List<BackPackItem> items, double capacity)
        {
            _theVault = new ItemVault();
            _theBackPack = new BackPack(capacity);

            foreach (var item in items)
            {
                _theVault.AddItem(item);
            }
        }

        protected ItemVault TheVault
        {
            get { return _theVault; }
        }

        protected BackPack TheBackPack
        {
            get { return _theBackPack; }
        }

        public void Run()
        {
            Solve(TheBackPack.WeightCapacityLeft);
            TheBackPack.PrintContent();
            TheVault.PrintContent();
        }

        public abstract void Solve(double capacityLeft);
    }
}