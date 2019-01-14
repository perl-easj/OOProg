namespace FateV10.GearClasses
{
    /// <summary>
    /// A piece of Gear will fit into a gear "slot" on a Hero.
    /// A Hero may own many piecees of Gear for each slot, but
    /// can only equip one piece of Gear in each slot at any time.
    /// Pretty standard RPGMMO mechanics...
    /// </summary>
    public enum GearSlot
    {
        Head,
        Chest,
        Hands,
        Legs,
        Feet,
        LeftHand,
        RightHand
    }
}