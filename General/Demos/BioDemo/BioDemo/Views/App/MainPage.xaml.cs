using Windows.UI.Xaml.Controls;
using BioDemo.ViewModels.App;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BioDemo.Views.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // This line initialises the AppViewModel with a reference to
            // the named Frame element in the view.
            ((AppViewModel)DataContext).SetAppFrame(AppFrame);
        }
    }
}
