// HISTORIK:
// v.1.0 : Oprettet
//

using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class CharacterDataViewModel : DataViewModelAppBase<Character>
    {
        public CharacterDataViewModel() {}

        public CharacterDataViewModel(Character dataObject) : base(dataObject)
        {
        }

        public string Name
        {
            get { return DataObject().Name; }
            set
            {
                DataObject().Name = value;
                OnPropertyChanged();
            }
        }

        public string HP
        {
            get { return DataObject().HealthPoints.ToString(); }
            set
            {
                bool couldParse = int.TryParse(value, out var hp);
                DataObject().HealthPoints = couldParse ? hp : -1;
                OnPropertyChanged();
            }
        }

        public string Level
        {
            get { return DataObject().Level.ToString(); }
            set
            {
                bool couldParse = int.TryParse(value, out var level);
                DataObject().Level = couldParse ? level : -1;
                OnPropertyChanged();
            }
        }

        protected override string ItemDescription
        {
            get { return $"{Name}"; }
        }
    }
}