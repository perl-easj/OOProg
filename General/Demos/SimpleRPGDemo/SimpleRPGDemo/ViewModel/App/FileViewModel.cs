using Windows.UI.Xaml;
using AddOns.UI.Implementation;
using Commands.Implementation;
using SimpleRPGDemo.Model.App;
using ViewModel.App.Implementation;

namespace SimpleRPGDemo.ViewModel.App
{
    public class FileViewModel : AppViewModelBase
    {
        private bool _isLoading;

        public FileViewModel()
        {
            _isLoading = false;
            AddCommands();
        }

        public bool IsWorking
        {
            get { return _isLoading; }
        }


        public string LoadingText
        {
            get { return _isLoading ? "Loading data..." : ""; }
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