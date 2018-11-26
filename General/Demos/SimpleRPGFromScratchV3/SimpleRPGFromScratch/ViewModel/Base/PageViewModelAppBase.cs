using System.Collections.Generic;
using System.Linq;
using SimpleRPGFromScratch.Command;
using SimpleRPGFromScratch.Command.App;
using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.Model.App;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.ViewModel.Base
{
    /// <summary>
    /// Dette er den PageViewModel-klasse, som alle de klasse-specifikke PageViewModel-klasser
    /// i denne applikation skal arve fra. Her beslutter vi, at
    /// 1) Alle katalog-referencer skal sættes ved at kalde DomainModel.GetCatalog.
    /// 2) Alle views skal have Create, Delete og Update-commands
    /// </summary>
    /// <typeparam name="T">Typen af de domæne-objekter, som kataloget rummer.</typeparam>
    /// <typeparam name="TDataViewModel">Typen for den tilsvarende Data View Model - klasse.</typeparam>
    public class PageViewModelAppBase<T, TDataViewModel> : PageViewModelBase<T, TDataViewModel> 
        where T : IDomainClass, new() 
        where TDataViewModel : class, IDataViewModel<T>, new()
    {
        /// <summary>
        /// Til hver tilstand af viewet hører et sæt af Commands.
        /// </summary>
        private Dictionary<PageViewModelState, Dictionary<string, CommandBase>> _allCommands;

        /// <summary>
        /// I constructoren sker tre ting.
        /// 1) Vi sætter samlingerne af Commands hørende til hver tilstand af viewet op.
        /// 2) Vi sikrer os at blive orienteret, npr viewet skifter tilstand.
        /// 3) Vi sætter viewet til at starte i Read/Delete-tilstanden.
        /// </summary>
        public PageViewModelAppBase()
        {
            // Command-objekter for Delete, Create og Update
            CommandBase deleteCmd = new DeleteCommand<T, TDataViewModel>(_catalog, this);
            CommandBase createCmd = new CreateCommand<T, TDataViewModel>(_catalog, this);
            CommandBase updateCmd = new UpdateCommand<T, TDataViewModel>(_catalog, this);

            // Command-objekter for at skifte til en specifik view-tilstand
            CommandBase setReadDeleteViewStateCmd = new SetViewStateCommand<TDataViewModel>(this, PageViewModelState.ReadDelete);
            CommandBase setCreateViewStateCmd = new SetViewStateCommand<TDataViewModel>(this, PageViewModelState.Create);
            CommandBase setUpdateViewStateCmd = new SetViewStateCommand<TDataViewModel>(this, PageViewModelState.Update);

            // I Read/Delete-tilstand er tre Commands til rådighed:
            // Create...: Skift til Create-tilstanden
            // Update...: Skift til Update-tilstanden
            // Delete : Slet det objekt, som p.t. er udvalgt.
            Dictionary<string, CommandBase> readDeleteCommands = new Dictionary<string, CommandBase>();
            readDeleteCommands.Add("Create...", setCreateViewStateCmd);
            readDeleteCommands.Add("Update...", setUpdateViewStateCmd);
            readDeleteCommands.Add("Delete", deleteCmd);

            // I Create-tilstand er tre Commands til rådighed:
            // Read/Delete...: Skift til Read/Delete-tilstanden
            // New: Lav et nyt, tomt objekt, som ikke er indsat i databasen endnu.
            // Save: Indsæt objektet i databasen.
            Dictionary<string, CommandBase> createCommands = new Dictionary<string, CommandBase>();
            createCommands.Add("Read/Delete...", setReadDeleteViewStateCmd);
            createCommands.Add("New", setCreateViewStateCmd);
            createCommands.Add("Save", createCmd);

            // I Update-tilstand er tre Commands til rådighed:
            // Read/Delete...: Skift til Read/Delete-tilstanden
            // Create...: Skift til Create-tilstanden
            // Update: Opdater databasen med de udførte ændringer til det udvalgte objekt.
            Dictionary<string, CommandBase> updateCommands = new Dictionary<string, CommandBase>();
            updateCommands.Add("Read/Delete...", setReadDeleteViewStateCmd);
            updateCommands.Add("Create...", setCreateViewStateCmd);
            updateCommands.Add("Update", updateCmd);

            // Lav den endelige samling af Commands hørende til hver tilstand
            _allCommands = new Dictionary<PageViewModelState, Dictionary<string, CommandBase>>();
            _allCommands.Add(PageViewModelState.ReadDelete, readDeleteCommands);
            _allCommands.Add(PageViewModelState.Create, createCommands);
            _allCommands.Add(PageViewModelState.Update, updateCommands);

            // Hook OnViewStateHasChanged op til at blive kalde,
            // når tilstanden af viewet ændres.
            _viewStateChanged += OnViewStateHasChanged;

            // Start viewet i read/Delete-tilstanden.
            SetState(PageViewModelState.ReadDelete);
        }

        /// <summary>
        /// Returnerer beskrivelser af aktuelle Commands, f.eks.
        /// til at sætte teksten i en kontrol via Data Binding.
        /// </summary>
        public List<string> ViewCommandsDesc
        {
            get { return CurrentCommands.Keys.ToList(); }
        }

        /// <summary>
        /// Returnerer aktuelle Command-objekter, som kan Data
        /// Bindes til UI-kontrollers Command-property.
        /// </summary>
        public List<CommandBase> ViewCommandsObj
        {
            get { return CurrentCommands.Values.ToList(); }
        }

        /// <summary>
        /// Returnerer teksten til en beskrivelse af viewets
        /// øjeblikkelige tilstand.
        /// </summary>
        public string ViewStateDesc
        {
            get
            {
                string header = "Tilstand: ";
                if (_state == PageViewModelState.ReadDelete) header += "Read/Delete";
                if (_state == PageViewModelState.Create) header += "Create";
                if (_state == PageViewModelState.Update) header += "Update";
                return header;
            }
        }

        /// <summary>
        /// Returnerer de Commands, som hører til viewet i dets nuværende tilstand.
        /// </summary>
        private Dictionary<string, CommandBase> CurrentCommands
        {
            get { return _allCommands[_state]; }
        }

        /// <summary>
        /// Sæt katalog-referencen v.h.a. DomainModel.GetCatalog.
        /// </summary>
        /// <returns>Reference til katalog som rummer objekter af typen T</returns>
        protected override ICatalog<T> GetCatalog()
        {
            return DomainModel.GetCatalog<T>();
        }

        /// <summary>
        /// Hver Command-object notificeres ved at kalde RaiseCanExecuteChanged på det.
        /// </summary>
        protected override void NotifyCommands()
        {
            foreach (var cmd in CurrentCommands.Values)
            {
                cmd.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Kaldes når tilstanden af viewet ændres, typisk fra et command-objekt.
        /// </summary>
        /// <param name="newState">Viewets nye tilstand</param>
        private void OnViewStateHasChanged(PageViewModelState newState)
        {
            OnPropertyChanged(nameof(ViewCommandsDesc));
            OnPropertyChanged(nameof(ViewCommandsObj));
            OnPropertyChanged(nameof(ViewStateDesc));
        }
    }
}