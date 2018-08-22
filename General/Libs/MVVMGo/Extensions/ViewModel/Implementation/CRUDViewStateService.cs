using System.Collections.Generic;
using AddOns.ViewState.Implementation;
using Extensions.Commands.Interfaces;

namespace Extensions.ViewModel.Implementation
{
    /// <summary>
    /// This class provides a specialisation of the ViewState 
    /// service to four states corresponding to CRUD operations.
    /// </summary>
    public class CRUDViewStateService : ViewStateService
    {
        public CRUDViewStateService() : base(new List<string>
        {
            CRUDStates.CreateState,
            CRUDStates.ReadState,
            CRUDStates.UpdateState,
            CRUDStates.DeleteState
        })
        {
        }
    }
}