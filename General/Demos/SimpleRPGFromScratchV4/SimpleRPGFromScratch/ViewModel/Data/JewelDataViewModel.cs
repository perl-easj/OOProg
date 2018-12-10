using System;
using System.Collections.ObjectModel;
using Windows.UI;
using Windows.UI.Xaml.Media;
using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.Model.App;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Control;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class JewelDataViewModel : DataViewModelAppBase<Jewel>
    {
        #region Instance fields
        private SelectionControlDVM<JewelModel, JewelModelDataViewModel> _jewelModelSCDVM;
        private SelectionControlDVM<JewelCutQuality, JewelCutQualityDataViewModel> _jewelCutQualitySCDVM;
        #endregion

        #region Initialise
        public override void Initialise()
        {
            _jewelModelSCDVM = new SelectionControlDVM<JewelModel, JewelModelDataViewModel>(
                () => DataObject().JewelModelId,
                val =>
                {
                    DataObject().JewelModelId = DomainClassBase<Jewel>.IdOrNullId(val);
                    DataObject().JewelModel = DomainModel.GetCatalog<JewelModel>().Read(DataObject().JewelModelId);
                    OnPropertyChanged(nameof(JewelModelSelected));
                    OnPropertyChanged(nameof(DamageDesc));
                });

            _jewelCutQualitySCDVM = new SelectionControlDVM<JewelCutQuality, JewelCutQualityDataViewModel>(
                () => DataObject().CutQualityId,
                val =>
                {
                    DataObject().CutQualityId = DomainClassBase<Jewel>.IdOrNullId(val);
                    DataObject().CutQuality = DomainModel.GetCatalog<JewelCutQuality>().Read(DataObject().CutQualityId);
                    OnPropertyChanged(nameof(JewelCQSelected));
                    OnPropertyChanged(nameof(DamageDesc));
                });
        }
        #endregion

        #region Simple properties
        public string DamageDesc
        {
            get { return $"{DataObject().BaseDamage:F0} ({DataObject().JewelModel?.BaseDamage})"; }
        }

        public string Description
        {
            get { return ItemDescription; }
        }

        public string ImageSource
        {
            get { return DataObject().JewelModel.ImageSource; }
        }

        public Color ItemBackgroundColor
        {
            get { return RarityTier.RarityColorMapper.ValueToColor(DataObject().JewelModel.RarityTier.Id); }
        }

        public SolidColorBrush ItemBackgroundColorBrush
        {
            get { return new SolidColorBrush(ItemBackgroundColor); }
        }

        public Color CircleStrokeColor
        {
            get { return JewelCutQuality.CutQualityColorMapper.ValueToColor(DataObject().CutQuality.Factor); }
        }

        public SolidColorBrush CircleStrokeColorBrush
        {
            get { return new SolidColorBrush(CircleStrokeColor); }
        }

        protected override string ItemDescription
        {
            get { return $"{DataObject().JewelModel?.Description} [{DataObject().CutQuality?.Description} cut]"; }
        } 
        #endregion

        #region Properties til understøttelse af Collection-kontroller
        public ObservableCollection<JewelModelDataViewModel> JewelModelCollection
        {
            get { return _jewelModelSCDVM.ItemCollection; }
        }

        public ObservableCollection<JewelCutQualityDataViewModel> JewelCQCollection
        {
            get { return _jewelCutQualitySCDVM.ItemCollection; }
        }

        public JewelModelDataViewModel JewelModelSelected
        {
            get { return _jewelModelSCDVM.ItemSelected; }
            set
            {
                _jewelModelSCDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }

        public JewelCutQualityDataViewModel JewelCQSelected
        {
            get { return _jewelCutQualitySCDVM.ItemSelected; }
            set
            {
                _jewelCutQualitySCDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public override int CompareTo(DataViewModelAppBase<Jewel> other)
        {
            int? idDiff = String.Compare(DataObject().JewelModel?.Description, other.DataObject().JewelModel?.Description, StringComparison.Ordinal);

            return (idDiff != null && idDiff.Value != 0) ? idDiff.Value : ((DataObject().BaseDamage - other.DataObject().BaseDamage) > 0 ? 1 : -1);
        }
    }
}