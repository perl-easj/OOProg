using System.Collections.ObjectModel;
using SimpleRPGFromScratch.Model.App;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Control;
using SimpleRPGFromScratch.ViewModel.Page;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class JewelDataViewModel : DataViewModelAppBase<Jewel>
    {
        private ComboBoxDataViewModel<JewelModel, JewelModelDataViewModel, JewelModelPageViewModel> _jewelModelCBDVM;
        private ComboBoxDataViewModel<JewelCutQuality, JewelCutQualityDataViewModel, JewelCutQualityPageViewModel> _jewelCutQualityCBDVM;

        public JewelDataViewModel() : this(null)
        {
        }

        public JewelDataViewModel(Jewel dataObject) : base(dataObject)
        {
            _jewelModelCBDVM = new ComboBoxDataViewModel<JewelModel, JewelModelDataViewModel, JewelModelPageViewModel>(
                () => DataObject().JewelModelId,
                val =>
                {
                    DataObject().JewelModelId = val;
                    DataObject().JewelModel = DomainModel.GetCatalog<JewelModel>().Read(DataObject().JewelModelId);
                    OnPropertyChanged(nameof(JewelModelSelected));
                    OnPropertyChanged(nameof(DamageDesc));
                });

            _jewelCutQualityCBDVM = new ComboBoxDataViewModel<JewelCutQuality, JewelCutQualityDataViewModel, JewelCutQualityPageViewModel>(
                () => DataObject().CutQualityId,
                val =>
                {
                    DataObject().CutQualityId = val;
                    DataObject().CutQuality = DomainModel.GetCatalog<JewelCutQuality>().Read(DataObject().CutQualityId);
                    OnPropertyChanged(nameof(JewelCQSelected));
                    OnPropertyChanged(nameof(DamageDesc));
                });
        }

        public ObservableCollection<JewelModelDataViewModel> JewelModelCollection
        {
            get { return _jewelModelCBDVM.ItemCollection; }
        }

        public ObservableCollection<JewelCutQualityDataViewModel> JewelCQCollection
        {
            get { return _jewelCutQualityCBDVM.ItemCollection; }
        }

        public JewelModelDataViewModel JewelModelSelected
        {
            get { return _jewelModelCBDVM.ItemSelected; }
            set
            {
                _jewelModelCBDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }

        public JewelCutQualityDataViewModel JewelCQSelected
        {
            get { return _jewelCutQualityCBDVM.ItemSelected; }
            set
            {
                _jewelCutQualityCBDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }

        public string DamageDesc
        {
            get { return $"{DataObject().BaseDamage:F2} ({DataObject().JewelModel?.BaseDamage})"; }
        }

        protected override string ItemDescription
        {
            get { return $"{DataObject().JewelModel?.Description} [{DataObject().CutQuality?.Description} cut], damage {DamageDesc}"; }
        }    
    }
}