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
        }

        public string HP
        {
            get { return $"{DataObject().HealthPoints} HP"; }
        }

        public string Level
        {
            get { return $"Level {DataObject().Level} character"; }
        }

        protected override string ItemDescription
        {
            get { return $"{Name}"; }
        }
    }
}