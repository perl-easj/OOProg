using Windows.UI.Xaml.Controls;
using SimpleRPGDemo.View.App;
using SimpleRPGDemo.ViewModel.App;

namespace SimpleRPGDemo.Configuration.App
{
    public class AppConfig
    {
        public static void Setup(Page mainPage, Frame appFrame)
        {
            appFrame.Navigate(typeof(FileView));
            ((MainPageViewModel)mainPage.DataContext).SetAppFrame(appFrame);
        }
    }
}