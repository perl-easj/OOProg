// HISTORIK:
// v.1.0 : Oprettet, minimalt interface for PageViewModel-klasser
//

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SimpleRPGFromScratch.ViewModel.Base
{
    /// <summary>
    /// Et meget minimalt interface for en Page View Model (PVM) - klasse.
    /// Et PVM-objekt vil være et objekt som
    /// 1) Rummer properties, som et view kan bruge til Data Binding for
    ///    kontroller der fremviser en collection af objekter.
    /// 1) Rummer properties, som et view kan bruge til Data Binding for
    ///    kontroller der kan udføre en Command.
    /// </summary>
    /// <typeparam name="TDataViewModel">Typen for de DVM-objekter, som properties returnerer.</typeparam>
    public interface IPageViewModel<TDataViewModel>
    {
        /// <summary>
        /// Denne property vil typisk bruges til Data Binding af property'en
        /// ItemsSource for f.eks. et ListView.
        /// </summary>
        ObservableCollection<TDataViewModel> ItemCollection { get; }

        /// <summary>
        /// Denne property vil typisk bruges til Data Binding af property'en
        /// SelectedItem for f.eks. et ListView.
        /// </summary>
        TDataViewModel ItemSelected { get; set; }


        /// <summary>
        /// Denne property vil typisk bruges til Data Binding af property'en
        /// Command for f.eks. en Button.
        /// </summary>
        ICommand DeleteCommandObj { get; }
    }
}