namespace AddOns.ControlState.Interfaces
{
    /// <summary>
    /// Types of "Mutability" for controls
    /// Mutable: Can be enabled after object creation.
    /// Immutable: Can never be enabled after object creation.
    /// </summary>
    public enum MutableType
    {
        Mutable, Immutable
    }
}