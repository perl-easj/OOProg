using System.Collections.Generic;
using FOOrrestGump.Interfaces;

namespace FOOrrestGump.FGScenarioChanged
{
    /// <summary>
    /// Class representing a whole box of chocolates.
    /// CHANGED: Now implements IConsumableContainer
    /// </summary>
    public class ChocolateBoxChanged : IConsumableContainer<ChocolateChanged>
    {
        private List<ChocolateChanged> _chocolates;

        public ChocolateBoxChanged()
        {
            _chocolates = new List<ChocolateChanged>();
        }

        public void AddChocolate(ChocolateChanged aChocolate)
        {
            _chocolates.Add(aChocolate);
        }

        public bool ChocolateLeft
        {
            get { return _chocolates.Count > 0; }
        }

        public bool Empty
        {
            get { return !ChocolateLeft; }
        }

        public ChocolateChanged TakeAChocolate()
        {
            if (!ChocolateLeft) return null;

            var item = _chocolates[_chocolates.Count - 1];
            _chocolates.RemoveAt(_chocolates.Count - 1);
            return item;
        }

        public ChocolateChanged TakeNext()
        {
            return TakeAChocolate();
        }
    }
}