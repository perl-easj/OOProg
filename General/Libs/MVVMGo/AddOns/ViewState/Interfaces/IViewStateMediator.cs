namespace AddOns.ViewState.Interfaces
{
    public interface IViewStateMediator
    {
        /// <summary>
        /// Invoked when the view state changes
        /// </summary>
        /// <param name="state">
        /// New view state
        /// </param>
        void OnViewStateChanged(string state);
    }
}