namespace NaiveRPG.Items.Armor
{
    /// <summary>
    /// Base class for all items considered to be armor.
    /// </summary>
    public abstract class ArmorBase : ItemBase
    {
        public abstract int ArmorPoints { get; }
    }
}