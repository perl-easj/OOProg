using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SlotMachineDemo.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SlotMachineDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            AppFrame.Navigate(typeof(NormalPlay));
        }
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            AppSplitView.IsPaneOpen = !AppSplitView.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NormalPlay.IsSelected)
            {
                AppFrame.Navigate(typeof(NormalPlay));
            }
            if (AutoPlay.IsSelected)
            {
                AppFrame.Navigate(typeof(AutoPlay));
            }
            if (NumericSettings.IsSelected)
            {
                AppFrame.Navigate(typeof(NumericSettings));
            }
            if (MachineSettings.IsSelected)
            {
                AppFrame.Navigate(typeof(MachineSettings));
            }
            if (Quit.IsSelected)
            {
                Application.Current.Exit();
            }
        }
    }
}
