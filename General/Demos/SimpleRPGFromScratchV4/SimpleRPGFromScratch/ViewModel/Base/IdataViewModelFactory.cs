namespace SimpleRPGFromScratch.ViewModel.Base
{
    public interface IDataViewModelFactory<T, out TDataViewModel>
    {
        TDataViewModel CreateDataViewModel(T obj);
    }
}