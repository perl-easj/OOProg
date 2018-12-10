using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using SimpleRPGFromScratch.Command.App;
using SimpleRPGFromScratch.Command.Domain;
using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.Model.App;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Control;
using SimpleRPGFromScratch.ViewModel.Page;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class WeaponDataViewModel : DataViewModelAppBaseRef<Weapon, WeaponPageViewModel>
    {
        #region Instance fields
        private SelectionControlDVM<WeaponModel, WeaponModelDataViewModel> _weaponModelSCDVM;

        private SelectionControlDVM<Jewel, JewelDataViewModel> _socketedJewelSCDVM;
        private int? _socketedJewelSelectedId;
        private ReferenceChangeCommand<Jewel> _dropJewelCommand;

        private SelectionControlDVM<Jewel, JewelDataViewModel> _freeJewelSCDVM;
        private int? _freeJewelSelectedId;
        private ReferenceChangeCommand<Jewel> _addJewelCommand;
        #endregion

        #region Initialise
        public override void Initialise()
        {
            _weaponModelSCDVM = new SelectionControlDVM<WeaponModel, WeaponModelDataViewModel>(
                () => DataObject().WeaponModelId,
                val =>
                {
                    DataObject().WeaponModelId = DomainClassBase<WeaponModel>.IdOrNullId(val);
                    OnPropertyChanged(nameof(WeaponModelSelected));
                });

            // Selection-control DVM for at kunne se/rette brugte Jewels
            _socketedJewelSCDVM = new SelectionControlDVM<Jewel, JewelDataViewModel>(
                () => SocketedJewelSelectedId,
                val => SocketedJewelSelectedId = val,
                j => j.WeaponId == DataObject().Id);

            // Selection-control DVM for at kunne se/rette frie Jewels
            _freeJewelSCDVM = new SelectionControlDVM<Jewel, JewelDataViewModel>(
                () => FreeJewelSelectedId,
                val => FreeJewelSelectedId = val,
                j => j.WeaponId == null);

            // Command-objekter til hhv. at droppe eller tilføje en Jewel
            _dropJewelCommand = new ReferenceChangeCommand<Jewel>(j => j.WeaponId = null);
            _addJewelCommand = new AddJewelToWeaponCommand(j => j.WeaponId = DataObject().Id, DataObject(), this);

            SocketedJewelSelectedId = null;
            FreeJewelSelectedId = null;

            // Da drop/tilføj vil medføre ændringer i Jewel-Cataloget, som udføres
            // fra Command-objekter, vil vi gerne notificeres om dette.
            DomainModel.GetCatalog<Jewel>().CatalogChanged += JewelCatalogChanged;
        } 
        #endregion

        #region Simple properties
        public string Description
        {
            get { return ItemDescription; }
        }

        public string ModelDescription
        {
            get { return DataObject().WeaponModel?.Description; }
        }

        public string TypeDescription
        {
            get { return DataObject().WeaponModel?.WeaponType?.Description; }
        }

        public string SocketsDescription
        {
            get { return $"{DataObject().Sockets}"; }
        }

        public string DamageDescription
        {
            get { return $"{DataObject().MinDamage} - {DataObject().MaxDamage}"; }
        }

        public string OwnerDescription
        {
            get { return DataObject().Character != null ? DataObject().Character.Name : "(none)"; }
        }

        protected override string ItemDescription
        {
            get
            {
                return DataObject().WeaponModel == null ? "" :
                    $"{DataObject().WeaponModel?.Description} #{DataObject().Id}  " +
                    $"({DataObject().WeaponModel?.WeaponType?.Description})";
            }
        }
        #endregion

        #region Properties til understøttelse af Collection-kontroller
        public ObservableCollection<WeaponModelDataViewModel> WeaponModelCollection
        {
            get { return _weaponModelSCDVM.ItemCollection; }
        }

        public WeaponModelDataViewModel WeaponModelSelected
        {
            get { return _weaponModelSCDVM.ItemSelected; }
            set
            {
                _weaponModelSCDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<JewelDataViewModel> SocketedJewelCollection
        {
            get { return _socketedJewelSCDVM.ItemCollection; }
        }

        public JewelDataViewModel SocketedJewelSelected
        {
            get { return _socketedJewelSCDVM.ItemSelected; }
            set
            {
                _socketedJewelSCDVM.ItemSelected = value;
            }
        }

        public bool SocketedJewelCollectionEnabled
        {
            get { return (SocketsUsed > 0) /*&& _pvm.EnabledStateCollection*/; }
        }

        public ObservableCollection<JewelDataViewModel> FreeJewelCollection
        {
            get { return _freeJewelSCDVM.ItemCollection; }
        }

        public JewelDataViewModel FreeJewelSelected
        {
            get { return _freeJewelSCDVM.ItemSelected; }
            set
            {
                _freeJewelSCDVM.ItemSelected = value;
            }
        }

        public bool FreeJewelCollectionEnabled
        {
            get { return (SocketsUsed < DataObject().Sockets) /*&& _pvm.EnabledStateCollection*/; }
        }
        #endregion

        #region Properties til understøttelse af Command-kontroller
        public string DropJewelCommandText
        {
            get { return $"Drop {SocketedJewelSelected}"; }
        }

        public string AddJewelCommandText
        {
            get { return $"Add {FreeJewelSelected}"; }
        }

        public ICommand DropJewelCommandObj
        {
            get { return _dropJewelCommand; }
        }

        public ICommand AddJewelCommandObj
        {
            get { return _addJewelCommand; }
        }
        #endregion

        #region Private properties som benyttes ved callback fra DVM-objekter
        private int? SocketedJewelSelectedId
        {
            get { return _socketedJewelSelectedId; }
            set
            {
                _socketedJewelSelectedId = value;
                _dropJewelCommand.SetReferrerId(_socketedJewelSelectedId);
                _dropJewelCommand.RaiseCanExecuteChanged();

                OnPropertyChanged(nameof(SocketedJewelSelected));
                OnPropertyChanged(nameof(DropJewelCommandText));
            }
        }

        private int? FreeJewelSelectedId
        {
            get { return _freeJewelSelectedId; }
            set
            {
                _freeJewelSelectedId = value;
                _addJewelCommand.SetReferrerId(_freeJewelSelectedId);
                _addJewelCommand.RaiseCanExecuteChanged();

                OnPropertyChanged(nameof(FreeJewelSelected));
                OnPropertyChanged(nameof(AddJewelCommandText));
            }
        }
        #endregion

        #region Hjælpe-metoder/properties
        private void JewelCatalogChanged(int id)
        {
            SocketedJewelSelectedId = null;
            FreeJewelSelectedId = null;

            OnPropertyChanged(nameof(SocketedJewelCollection));
            OnPropertyChanged(nameof(FreeJewelCollection));
        }

        private int SocketsUsed
        {
            get { return DomainModel.GetCatalog<Jewel>().All.Count(jw => jw.WeaponId == DataObject().Id); }
        }
        #endregion
    }
}