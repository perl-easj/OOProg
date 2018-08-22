using System.Collections.Generic;
using Windows.UI.Text;
using Data.InMemory.Interfaces;
using Extensions.Commands.Interfaces;
using Extensions.ViewModel.Implementation;
using Model.Interfaces;

namespace CarRetailDemo.ViewModels.Base
{
    public abstract class PageViewModelAppBase<TViewData> : PageViewModelCRUD<TViewData> 
        where TViewData : class, ICopyable, IStorable, new()
    {
        Dictionary<string, FontWeight> _menuFontWeights;

        protected PageViewModelAppBase(ICatalog<TViewData> catalog, List<string> immutableControls, List<string> mutableControls)
            : base(catalog, immutableControls, mutableControls)
        {
            _menuFontWeights = new Dictionary<string, FontWeight>();
            UpdateFontWeights();

            ViewStateService.ViewStateChanged += s =>
            {
                UpdateFontWeights();
                OnPropertyChanged(nameof(MenuFontWeights));
            };
        }

        public Dictionary<string, FontWeight> MenuFontWeights
        {
            get { return _menuFontWeights; }
        }

        private void UpdateFontWeights()
        {
            _menuFontWeights.Clear();

            _menuFontWeights.Add("CreateMenuItem", ViewStateService.ViewState == CRUDStates.CreateState ? FontWeights.Bold : FontWeights.Normal);
            _menuFontWeights.Add("ReadMenuItem", ViewStateService.ViewState == CRUDStates.ReadState ? FontWeights.Bold : FontWeights.Normal);
            _menuFontWeights.Add("UpdateMenuItem", ViewStateService.ViewState == CRUDStates.UpdateState ? FontWeights.Bold : FontWeights.Normal);
            _menuFontWeights.Add("DeleteMenuItem", ViewStateService.ViewState == CRUDStates.DeleteState ? FontWeights.Bold : FontWeights.Normal);
        }
    }
}