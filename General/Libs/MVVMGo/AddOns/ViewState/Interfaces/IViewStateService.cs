namespace AddOns.ViewState.Interfaces
{
    /// <summary>
    /// Interface for a simple view state service. 
    /// The view state can be set and retrieved. 
    /// No assumption about specific view states 
    /// are made.
    /// </summary>
    public interface IViewStateService : IViewStateChangedEvent
    {
        /// <summary>
        /// View state of object.
        /// </summary>
        string ViewState { get; set; }
    }
}