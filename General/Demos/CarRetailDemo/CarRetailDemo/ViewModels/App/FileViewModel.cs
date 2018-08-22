using Windows.UI.Xaml;
using AddOns.UI.Implementation;
using Commands.Implementation;
using CarRetailDemo.Models.App;
using ViewModel.App.Implementation;

namespace CarRetailDemo.ViewModels.App
{
    public class FileViewModel : AppViewModelBase
    {
        private bool _isLoading;
        private bool _isSaving;

        public FileViewModel()
        {
            _isLoading = false;
            _isSaving = false;

            AddCommands();
        }

        public bool IsWorking
        {
            get { return _isLoading || _isSaving; }
        }


        public string LoadingText
        {
            get
            {
                if (_isLoading)
                {
                    return "Loading data...";
                }
                if (_isSaving)
                {
                    return "Saving data...";
                }
                return "";
            }
        }

        private void OnLoadingBegins()
        {
            _isLoading = true;
            UpdateOnStateChange();
        }

        private void OnLoadingEnds()
        {
            _isLoading = false;
            UpdateOnStateChange();
        }

        private void OnSavingBegins()
        {
            _isSaving = true;
            UpdateOnStateChange();
        }

        private void OnSavingEnds()
        {
            _isSaving = false;
            UpdateOnStateChange();
        }

        private void UpdateOnStateChange()
        {
            OnPropertyChanged(nameof(IsWorking));
            OnPropertyChanged(nameof(LoadingText));
        }

        public override void AddCommands()
        {
            NavigationCommands.Add("Load", new RelayCommandAsync(async () =>
            {
                OnLoadingBegins();
                DialogWithReturnValue.ReturnValueType retVal = await DialogWithReturnValue.PresentDialogWithReturnValue("Are you sure you want to LOAD model data?", "LOAD");
                if (retVal == DialogWithReturnValue.ReturnValueType.OK)
                {
                    DomainModel.Instance.LoadEnds += OnLoadingEnds;
                    await DomainModel.Instance.LoadAsync();
                }
                else
                {
                    OnLoadingEnds();
                }
            }));

            NavigationCommands.Add("Save", new RelayCommandAsync(async () =>
            {
                OnSavingBegins();
                DialogWithReturnValue.ReturnValueType retVal = await DialogWithReturnValue.PresentDialogWithReturnValue("Are you sure you want to SAVE model data?", "SAVE");
                if (retVal == DialogWithReturnValue.ReturnValueType.OK)
                {
                    DomainModel.Instance.LoadEnds += OnSavingEnds;
                    await DomainModel.Instance.SaveAsync();
                }
                else
                {
                    OnSavingEnds();
                }
            }));

            NavigationCommands.Add("Quit", new RelayCommandAsync(async () =>
            {
                DialogWithReturnValue.ReturnValueType retVal = await DialogWithReturnValue.PresentDialogWithReturnValue("Are you sure you want to QUIT?", "QUIT");
                if (retVal == DialogWithReturnValue.ReturnValueType.OK)
                {
                    Application.Current.Exit();
                }
            }));
        }
    }
}