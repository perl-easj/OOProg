using BioDemo.Models.App;
using Commands.Implementation;

namespace BioDemo.ViewModels.Commands
{
    /// <summary>
    /// Command class implementing Save of entire domain model.
    /// </summary>
    public class SaveCommand : CommandBase
    {
        protected override void Execute()
        {
            DomainModel.Instance.SaveAsync();
        }
    }
}