using Data.InMemory.Interfaces;
using SimpleRPGDemo.Data;
using SimpleRPGDemo.Model.App;
using SimpleRPGDemo.ViewModel.Base;
using SimpleRPGDemo.ViewModel.Data;

namespace SimpleRPGDemo.ViewModel.Page
{
    public class RarityTierPageViewModel : PageViewModelAppBase<RarityTier>
    {
        public RarityTierPageViewModel() : base(DomainModel.Catalogs.RarityTiers)
        {
        }

        public override IDataWrapper<RarityTier> CreateDataViewModel(RarityTier obj)
        {
            return new RarityTierDataViewModel(obj);
        }
    }
}