using System;

namespace AddOns.ViewState.Interfaces
{
    /// <summary>
    /// Clients interested in being notified 
    /// about changes in the view state of the 
    /// object can register at the event
    /// defined in this interface.
    /// </summary>
    public interface IViewStateChangedEvent
    {
        event Action<string> ViewStateChanged;
    }
}