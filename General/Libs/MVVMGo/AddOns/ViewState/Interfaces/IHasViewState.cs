namespace AddOns.ViewState.Interfaces
{
    /// <summary>
    /// Any object that has a "view state" 
    /// should implement this interface.
    /// </summary>
    public interface IHasViewState
    {
        /// <summary>
        /// Current view state of object.
        /// </summary>
        string ViewState { get; }
    }
}