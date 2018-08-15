using System;
using System.Collections.Generic;
using BackPacking.Containers;
using BackPacking.Item;

namespace BackPacking.Algorithms
{
    /// <summary>
    /// Base class for classes implementing a specific algorithm for
    /// packing a backpack. The items provided in the constructor are
    /// inserted into an item vault, which is then used when calling
    /// the Solve method.
    /// </summary>
    public abstract class BackPackingSolverBase : IBackPackingSolver
    {
        #region Instance fields
        protected ItemVault _theVault;
        protected BackPack _theBackPack; 
        #endregion

        #region Constructor
        protected BackPackingSolverBase(List<BackPackItem> items, double capacity)
        {
            _theVault = new ItemVault();
            _theBackPack = new BackPack(capacity);

            foreach (var item in items)
            {
                _theVault.AddItem(item);
            }
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Solves the backpacking problem, and prints out information
        /// about the solution.
        /// </summary>
        public void Run()
        {
            Solve(_theVault, _theBackPack);
            _theBackPack.PrintContent();
            Console.WriteLine();
            _theVault.PrintContent();
        }

        /// <summary>
        /// Override this method to implement a specific algorithm
        /// for backpacking.
        /// </summary>
        public abstract void Solve(ItemVault theItemVault, BackPack theBackPack); 
        #endregion
    }
}