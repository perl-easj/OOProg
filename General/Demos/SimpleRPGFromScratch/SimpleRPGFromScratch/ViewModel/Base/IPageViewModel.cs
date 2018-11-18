// HISTORIK:
// v.1.0 : Oprettet, minimalt interface for PageViewModel-klasser
//

using System.Collections.ObjectModel;

namespace SimpleRPGFromScratch.ViewModel.Base
{
    public interface IPageViewModel<TDataViewModel>
    {
        ObservableCollection<TDataViewModel> ItemCollection { get; }
        TDataViewModel ItemSelected { get; set; }
    }
}