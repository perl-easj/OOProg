using BioDemo.Models.App;
using Commands.Implementation;

namespace BioDemo.ViewModels.Commands
{
    /// <summary>
    /// Command class implementing Load of entire domain model.
    /// </summary>
    public class LoadCommand : CommandBase
    {
        protected override void Execute()
        {
            DomainModel.Instance.LoadAsync();
        }
    }
}