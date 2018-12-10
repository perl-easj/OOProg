using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch.ViewModel.Base
{
    public interface IDataViewModelRef<T, in TPageViewModel> : IDataViewModel<T> 
        where T : IDomainClass
    {
        /// <summary>
        /// Sætter referencen til den omgivende PageViewModel.
        /// </summary>
        /// <param name="obj">Reference til den omgivende PageViewModel.</param>
        void SetPageViewModel(TPageViewModel obj);
    }
}