using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch.ViewModel.Base
{
    public abstract class DataViewModelAppBaseRef<T, TPageViewModel> : DataViewModelAppBase<T>, IDataViewModelRef<T, TPageViewModel> 
        where T : class, IDomainClass, new() 
        where TPageViewModel : class
    {
        protected TPageViewModel _pvm;

        protected DataViewModelAppBaseRef()
        {
            _pvm = null;
        }

        public void SetPageViewModel(TPageViewModel pvm)
        {
            _pvm = pvm;
        }
    }
}