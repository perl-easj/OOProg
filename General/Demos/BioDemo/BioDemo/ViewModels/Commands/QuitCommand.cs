using Windows.UI.Xaml;
using Commands.Implementation;

namespace BioDemo.ViewModels.Commands
{
    /// <summary>
    /// Command class implementing application shutdown.
    /// </summary>
    public class QuitCommand : CommandBase
    {
        protected override void Execute()
        {
            Application.Current.Exit();
        }
    }
}