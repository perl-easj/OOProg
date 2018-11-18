// HISTORIK:
// v.1.0 : Oprettet, minimalt interface for DataViewModel-klasser
//

namespace SimpleRPGFromScratch.ViewModel.Base
{
    public interface IDataViewModel<out T>
    {
        T DataObject { get; }
    }
}