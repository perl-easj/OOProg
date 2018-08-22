using SlotMachineDemo.Types;

namespace SlotMachineDemo.Implementations.ViewModels
{
    /// <summary>
    /// Helper class for displaying a winnings entry in a 
    /// collection-oriented UI control, e.g. a ListView.
    /// Ties together three wheel symbols and a winnings amount.
    /// </summary>
    public class ItemViewModelWinningsEntry
    {
        private readonly WheelSymbolCount _wsCount;
        private readonly int _winAmount;

        public ItemViewModelWinningsEntry(WheelSymbolCount wsCount, int winAmount)
        {
            _wsCount = wsCount;
            _winAmount = winAmount;
        }

        public Enums.WheelSymbol Symbol
        {
            get { return _wsCount.Symbol; }
        }

        public int Count
        {
            get { return _wsCount.Count; }
        }

        public int WinningsAmount
        {
            get { return _winAmount; }
        }

        public string Image1Source
        {
            get { return Count > 0 ? Configuration.Setup.RunTimeSettings.WheelImage.GetImageSource(Symbol) : ""; }
        }

        public string Image2Source
        {
            get { return Count > 1 ? Configuration.Setup.RunTimeSettings.WheelImage.GetImageSource(Symbol) : ""; }
        }

        public string Image3Source
        {
            get { return Count > 2 ? Configuration.Setup.RunTimeSettings.WheelImage.GetImageSource(Symbol) : ""; }
        }

        public override bool Equals(object obj)
        {
            ItemViewModelWinningsEntry other = (ItemViewModelWinningsEntry)obj;

            if (other != null)
            {
                return (Symbol == other.Symbol && Count == other.Count);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _wsCount.GetHashCode();
        }
    }
}