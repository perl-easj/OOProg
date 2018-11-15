using Commands.Implementation;
using Extensions.ViewModel.Implementation;
using SimpleRPGDemo.View.App;
using SimpleRPGDemo.View.Domain;

namespace SimpleRPGDemo.ViewModel.App
{
    public class MainPageViewModel : AppViewModelMenu
    {
        public override void AddCommands()
        {
            NavigationCommands.Add("OpenFileView", new NavigationCommand(AppFrame, typeof(FileView)));
            NavigationCommands.Add("OpenRarityTierView", new NavigationCommand(AppFrame, typeof(RarityTierView)));
        }   
    }
}