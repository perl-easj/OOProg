using System;
using System.Collections.Generic;
using System.Linq;
using BackPacking.Item;

namespace BackPacking.Containers
{
    /// <summary>
    /// This class serves as a base class for all classes containing 
    /// BackPackItem objects. You can essentially:
    /// 1) Retrieve all items in the container
    /// 2) Add items to the container
    /// 3) Remove items from the container
    /// </summary>
    public class BackPackItemContainer
    {
        private string _containerDescription;
        private Dictionary<string, BackPackItem> _items;

        public BackPackItemContainer(string containerDescription)
        {
            _containerDescription = containerDescription;
            _items = new Dictionary<string, BackPackItem>();
        }

        /// <summary>
        /// Return all BackPackItem objects in the container
        /// </summary>
        public List<BackPackItem> Items
        {
            get { return _items.Values.ToList(); }
        }

        #region Methods
        /// <summary>
        /// Removes and returns the item corresponding to the given description.
        /// An exception is thrown if no matching item is found.
        /// </summary>
        public virtual BackPackItem RemoveItem(string description)
        {
            if (!_items.ContainsKey(description))
            {
                throw new ArgumentException(description + " is not in the " + _containerDescription + "!");
            }

            BackPackItem removedItem = _items[description];
            _items.Remove(description);

            return removedItem;
        }

        /// <summary>
        /// Adds the given item to the container. An exception is thrown if
        /// an item with the same description is already in the container.
        /// </summary>
        public virtual void AddItem(BackPackItem item)
        {
            if (_items.ContainsKey(item.Description))
            {
                throw new ArgumentException(item.Description + " is already in the " + _containerDescription + "!");
            }

            _items.Add(item.Description, item);
        }

        /// <summary>
        /// Neatly prints out the content of the container
        /// </summary>
        public virtual void PrintContent()
        {
            Console.WriteLine($"The {_containerDescription} contains:");
            Console.WriteLine("----------------------");
            foreach (BackPackItem item in Items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------");
        } 
        #endregion
    }
}