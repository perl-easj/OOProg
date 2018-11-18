using SimpleRPGFromScratch.Model.Base;
using SimpleRPGFromScratch.Model.Catalog;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Data;

namespace SimpleRPGFromScratch.ViewModel.Page
{
    public class CharacterPageViewModel : PageViewModelBase<Character, CharacterDataViewModel>
    {
        protected override CharacterDataViewModel GenerateDataViewModel(Character obj)
        {
            return new CharacterDataViewModel(obj);
        }

        protected override ICatalog<Character> GenerateCatalog()
        {
            return new CharacterCatalog();
        }
    }
}