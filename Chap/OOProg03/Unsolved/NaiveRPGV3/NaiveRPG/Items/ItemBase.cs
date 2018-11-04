using NaiveRPG.Interfaces;

namespace NaiveRPG.Items
{
    public abstract class ItemBase : IItem
    {
        public override string ToString()
        {
            return Description;
        }

        public abstract string Description { get; }
    }
}