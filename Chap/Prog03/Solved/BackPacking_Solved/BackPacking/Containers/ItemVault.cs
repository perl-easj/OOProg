namespace BackPacking.Containers
{
    /// <summary>
    /// An ItemVault is just a specific kind of item container.
    /// We imagine that an ItemVault contains all those items
    /// you might consider to pack into your backpack.
    /// </summary>
    public class ItemVault : BackPackItemContainer
    {
        public ItemVault() : base("Vault")
        {
        }
    }
}