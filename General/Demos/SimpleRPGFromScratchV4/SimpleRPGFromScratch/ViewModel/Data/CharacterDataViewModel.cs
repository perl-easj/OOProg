using System.Collections.ObjectModel;
using System.Windows.Input;
using SimpleRPGFromScratch.Command.App;
using SimpleRPGFromScratch.Model.App;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Control;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    /// <summary>
    /// Denne klasse rummer funktionalitet til at understøtte visning af et
    /// enkelt Character-objekt. En væsentlig komplikation er, at en Character
    /// kan eje et antal Weapon (og et Weapon kan kun ejes af nul/en Character),
    /// d.v.s. Weapon-objekter har en reference til et Character-objekt.
    /// I Character-viewet vil vi gerne for hver Character kunne:
    /// 1) Se (og rette) basis-oplysninger om en Character (Navn, Level og Health-points
    /// 2) Se (og rette) hvilke Weapon som den valgte Character ejer.
    /// Ønske 2) udføres ved at vise to collections af Weapon-objekter
    /// a) De Weapon-objekter, som den valgte Character ejer.
    /// b) De Weapon-objekter, som ingen ejer.
    /// Det antages, at vi frit kan tilføje Weapons fra samlingen af "frie"
    /// Weapon-objeket til den valgte Characters samling af ejede Weapons.
    /// Ligeledes kan vi "droppe" Weapons fra samlingen af ejede Weapons.
    /// </summary>
    public class CharacterDataViewModel : DataViewModelAppBase<Character>
    {
        #region Instance fields
        private const int HPScaleFactor = 10;

        private IntSliderDataViewModel _levelSliderDVM;
        private IntSliderDataViewModel _hpSliderDVM;

        private SelectionControlDVM<Weapon, WeaponDataViewModel> _ownedWeaponControlDVM;
        private int? _ownedWeaponSelectedId;
        private ReferenceChangeCommand<Weapon> _dropWeaponCommand;

        private SelectionControlDVM<Weapon, WeaponDataViewModel> _freeWeaponControlDVM;
        private int? _freeWeaponSelectedId;
        private ReferenceChangeCommand<Weapon> _addWeaponCommand;
        #endregion

        #region Initialise
        public override void Initialise()
        {
            // Integer-slider DVM for at kunne se/rette Health Points
            _hpSliderDVM = new IntSliderDataViewModel(
                Character.MaxHealthPoints,
                HPScaleFactor,
                () => DataObject().HealthPoints,
                val =>
                {
                    DataObject().HealthPoints = val;
                    OnPropertyChanged(nameof(HealthPointsIndex));
                    OnPropertyChanged(nameof(HealthPoints));
                });

            // Integer-slider DVM for at kunne se/rette Level
            _levelSliderDVM = new IntSliderDataViewModel(
                Character.MaxLevel,
                () => DataObject().Level,
                val =>
                {
                    DataObject().Level = val;
                    OnPropertyChanged(nameof(LevelIndex));
                    OnPropertyChanged(nameof(Level));
                });

            // Selection-control DVM for at kunne se/rette ejede Weapon
            _ownedWeaponControlDVM = new SelectionControlDVM<Weapon, WeaponDataViewModel>(
                () => OwnedWeaponSelectedId,
                val => OwnedWeaponSelectedId = val,
                w => w.CharacterId == DataObject().Id);

            // Selection-control DVM for at kunne se/rette frie Weapon
            _freeWeaponControlDVM = new SelectionControlDVM<Weapon, WeaponDataViewModel>(
                () => FreeWeaponSelectedId,
                val => FreeWeaponSelectedId = val,
                w => w.CharacterId == null);

            // Command-objekter til hhv. at droppe eller tilføje et Weapon
            _dropWeaponCommand = new ReferenceChangeCommand<Weapon>(w => w.CharacterId = null);
            _addWeaponCommand = new ReferenceChangeCommand<Weapon>(w => w.CharacterId = DataObject().Id);

            OwnedWeaponSelectedId = null;
            FreeWeaponSelectedId = null;

            // Da drop/tilføj vil medføre ændringer i Weapon-Cataloget, som udføres
            // fra Command-objekter, vil vi gerne notificeres om dette.
            DomainModel.GetCatalog<Weapon>().CatalogChanged += WeaponCatalogChanged;
        }
        #endregion

        #region Simple properties
        public string Name
        {
            get { return DataObject().Name; }
            set
            {
                DataObject().Name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsDataObjectValid));
            }
        }

        protected override string ItemDescription
        {
            get { return $"{Name}"; }
        }
        #endregion

        #region Properties til understøttelse af Slider-kontroller
        public int HealthPointsIndex
        {
            get { return _hpSliderDVM.SliderIndex; }
            set { _hpSliderDVM.SliderIndex = value; }
        }

        public string HealthPoints
        {
            get { return _hpSliderDVM.SliderText; }
        }

        public int HealthPointsScaleMax
        {
            get { return _hpSliderDVM.SliderScaleMax; }
        }

        public int LevelIndex
        {
            get { return _levelSliderDVM.SliderIndex; }
            set { _levelSliderDVM.SliderIndex = value; }
        }

        public string Level
        {
            get { return _levelSliderDVM.SliderText; }
        }

        public int LevelScaleMax
        {
            get { return _levelSliderDVM.SliderScaleMax; }
        }
        #endregion

        #region Properties til understøttelse af Collection-kontroller
        public ObservableCollection<WeaponDataViewModel> OwnedWeaponCollection
        {
            get { return _ownedWeaponControlDVM.ItemCollection; }
        }

        public WeaponDataViewModel OwnedWeaponSelected
        {
            get { return _ownedWeaponControlDVM.ItemSelected; }
            set
            {
                _ownedWeaponControlDVM.ItemSelected = value;
            }
        }

        public ObservableCollection<WeaponDataViewModel> FreeWeaponCollection
        {
            get { return _freeWeaponControlDVM.ItemCollection; }
        }

        public WeaponDataViewModel FreeWeaponSelected
        {
            get { return _freeWeaponControlDVM.ItemSelected; }
            set
            {
                _freeWeaponControlDVM.ItemSelected = value;
            }
        }
        #endregion

        #region Properties til understøttelse af Command-kontroller
        public string DropWeaponCommandText
        {
            get { return $"Drop {OwnedWeaponSelected}"; }
        }

        public string AddWeaponCommandText
        {
            get { return $"Add {FreeWeaponSelected}"; }
        }

        public ICommand DropWeaponCommandObj
        {
            get { return _dropWeaponCommand; }
        }

        public ICommand AddWeaponCommandObj
        {
            get { return _addWeaponCommand; }
        }
        #endregion

        #region Private properties som benyttes ved callback fra DVM-objekter
        /// <summary>
        /// Når der sker en ændring af valget i kontrollen som viser ejede
        /// Weapon-objekter, vil DVM for denne kontrol kalde tilbage til
        /// denne property (via en callback-metode). Her skal vi altså definere
        /// hvad der skal ske, når ændringen er sket:
        /// 1) Gem det nye id for det valgte Weapon.
        /// 2) Videregiv id'et til "drop weapon"-Command-objeket
        /// 3) Kald relevante OnPropertyChanged
        /// </summary>
        private int? OwnedWeaponSelectedId
        {
            get { return _ownedWeaponSelectedId; }
            set
            {
                _ownedWeaponSelectedId = value;
                _dropWeaponCommand.SetReferrerId(_ownedWeaponSelectedId);
                _dropWeaponCommand.RaiseCanExecuteChanged();

                OnPropertyChanged(nameof(OwnedWeaponSelected));
                OnPropertyChanged(nameof(DropWeaponCommandText));
            }
        }

        /// <summary>
        /// Denne property tjener samme formål som OwnedWeaponSelectedId,
        /// (se denne) blot for samlingen af frie Weapon-objekter.
        /// </summary>
        private int? FreeWeaponSelectedId
        {
            get { return _freeWeaponSelectedId; }
            set
            {
                _freeWeaponSelectedId = value;
                _addWeaponCommand.SetReferrerId(_freeWeaponSelectedId);
                _addWeaponCommand.RaiseCanExecuteChanged();

                OnPropertyChanged(nameof(FreeWeaponSelected));
                OnPropertyChanged(nameof(AddWeaponCommandText));
            }
        }
        #endregion

        #region Hjælpe-metoder
        /// <summary>
        /// Denne metode bliver kaldt, når der sker ændringer i
        /// Weapon-kataloget. Når dette sker, vil vi:
        /// 1) Fjerne selektioner i begge Weapon-samlinger.
        /// 2) Genopfriske begge Weapon-samlinger.
        /// </summary>
        private void WeaponCatalogChanged(int obj)
        {
            OwnedWeaponSelected = null;
            FreeWeaponSelected = null;

            OnPropertyChanged(nameof(OwnedWeaponCollection));
            OnPropertyChanged(nameof(FreeWeaponCollection));
        }
        #endregion

        public override string ToString()
        {
            return $"{Name.PadRight(15)} {Level.ToString().PadRight(10)} {HealthPoints.ToString().PadRight(10)} HP";
        }
    }
}