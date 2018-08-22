using System.Collections.Generic;
using System.Collections.ObjectModel;
using SlotMachineDemo.Implementations.Properties;
using SlotMachineDemo.Interfaces.Logic;
using SlotMachineDemo.Interfaces.Properties;
using SlotMachineDemo.Interfaces.ViewModels;
using SlotMachineDemo.Types;

namespace SlotMachineDemo.Implementations.ViewModels
{
    /// <summary>
    /// View model for the winnings part of the setup. 
    /// </summary>
    public class ViewModelWinningsSetup : PropertySourceSink, IViewModelWinningsSetup
    {
        #region Instance fields
        private ILogicWinningsSetup _logicWinningsSetup;
        private TickScale _tickScale;
        private ItemViewModelWinningsEntry _entry;
        private ObservableCollection<ItemViewModelWinningsEntry> _winList;
        private ObservableCollection<ItemViewModelWinningsEntry> _winListCopy;
        #endregion

        #region Constructor
        public ViewModelWinningsSetup(
            List<IPropertySource> propertySources,
            ILogicWinningsSetup logicWinningsSetup,
            TickScale tickScale)
            : base(propertySources)
        {
            _logicWinningsSetup = logicWinningsSetup;
            _tickScale = tickScale;
            _entry = null;
            _winList = new ObservableCollection<ItemViewModelWinningsEntry>();
            _winListCopy = null;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Retrieves a collection of winnings entry objects,
        /// to display in a list-oriented control (e.g. a ListView).
        /// </summary>
        public ObservableCollection<ItemViewModelWinningsEntry> WinningsList
        {
            get
            {
                 _winList.Clear();
                foreach (var item in _logicWinningsSetup.WinningsSettingsComplete)
                {
                    _winList.Add(new ItemViewModelWinningsEntry(item.Key, item.Value));
                }

                return _winList;
            }
        }

        public ObservableCollection<ItemViewModelWinningsEntry> WinningsListCopy
        {
            get
            {
                if (_winListCopy == null)
                {
                    _winListCopy = new ObservableCollection<ItemViewModelWinningsEntry>();
                    foreach (var item in _logicWinningsSetup.WinningsSettingsComplete)
                    {
                        _winListCopy.Add(new ItemViewModelWinningsEntry(item.Key, item.Value));
                    }
                }

                return _winListCopy;
            }
        }

        /// <summary>
        /// Tracks the winnings entry currently selected by the user.
        /// </summary>
        public ItemViewModelWinningsEntry WinningsSelected
        {
            get { return _entry; }
            set
            {
                // Selection is kept even if selection becomes null,
                // to enable continuous update of an entry
                if (value != null)
                {
                    _entry = value;
                }
                OnPropertyChanged(nameof(WinningsTick));
                OnPropertyChanged(nameof(WinningsAmount));
            }
        }

        /// <summary>
        /// Tracks the setting of a ticker-based control
        /// (e.g. a Slider) for setting the winnings amount 
        /// for the currently selected winnings entry.
        /// Zero is returned if no entry is selected.
        /// </summary>
        public int WinningsTick
        {
            get
            {
                if (_entry == null)
                {
                    return 0;
                }

                return _tickScale.ScaleToTick(_logicWinningsSetup.GetWinnings(_entry.Symbol, _entry.Count));
            }
            set
            {
                int newWinnings = _tickScale.TickToScale(value);
                if (_entry != null)
                {
                    _logicWinningsSetup.SetWinnings(_entry.Symbol, _entry.Count, newWinnings);
                    UpdateItem(new WheelSymbolCount(_entry.Symbol, _entry.Count), newWinnings);
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(WinningsAmount));
                }
            }
        }

        /// <summary>
        /// The winnings amount for the currently selected winnings entry.
        /// Zero is returned if no entry is sselected.
        /// </summary>
        public int WinningsAmount
        {
            get
            {
                if (_entry == null)
                {
                    return 0;
                }

                return _logicWinningsSetup.GetWinnings(_entry.Symbol, _entry.Count);
            }
        }

        /// <summary>
        /// Retrieves the set of currently active wheel symbol images.
        /// </summary>
        public Dictionary<string, string> WheelSymbolImages
        {
            get { return Configuration.Setup.RunTimeSettings.WheelImage.GetAllImageSources(); }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Update the winnings entry corresponding to the specified wheel symbols.
        /// </summary>
        private void UpdateItem(WheelSymbolCount wsCount, int newWinnings)
        {
            ItemViewModelWinningsEntry entry = new ItemViewModelWinningsEntry(wsCount, newWinnings);

            for (int index = 0; index < _winList.Count; index++)
            {
                if (_winList[index].Equals(entry))
                {
                    // We found the matching entry, so update it by deleting
                    // and re-inserting with the updated winnings amount.
                    _winList.RemoveAt(index);
                    _winList.Insert(index, entry);
                    return;
                }
            }
        }
        #endregion
    }
}
