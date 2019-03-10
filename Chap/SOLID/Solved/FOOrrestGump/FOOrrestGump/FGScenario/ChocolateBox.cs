using System.Collections.Generic;

namespace FOOrrestGump.FGScenario
{
    /// <summary>
    /// Class representing a whole box of chocolates.
    /// </summary>
    public class ChocolateBox
    {
        private List<Chocolate> _chocolates;

        public ChocolateBox()
        {
            _chocolates = new List<Chocolate>();
        }

        public void AddChocolate(Chocolate aChocolate)
        {
            _chocolates.Add(aChocolate);
        }

        public bool ChocolateLeft
        {
            get { return _chocolates.Count > 0; }
        }

        public Chocolate TakeAChocolate()
        {
            if (!ChocolateLeft) return null;

            var item = _chocolates[_chocolates.Count - 1];
            _chocolates.RemoveAt(_chocolates.Count - 1);
            return item;
        }
    }
}