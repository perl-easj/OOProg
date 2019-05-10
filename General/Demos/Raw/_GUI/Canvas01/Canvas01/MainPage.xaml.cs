using System.Diagnostics;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
// ReSharper disable ArrangeThisQualifier
// ReSharper disable RedundantExtendsListEntry
// ReSharper disable PossibleLossOfFraction

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Canvas01
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainCanvas.Instance.TheCanvas = theCanvas;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown += CoreWindowOnKeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindowOnKeyUp;
            Window.Current.CoreWindow.PointerPressed += CoreWindowOnPointerPressed;
        }

        private void CoreWindowOnPointerPressed(CoreWindow sender, PointerEventArgs args)
        {
            double x = args.CurrentPoint.Position.X;
            double y = args.CurrentPoint.Position.Y;
            double z = x + y;
        }

        private void CoreWindowOnKeyUp(CoreWindow sender, KeyEventArgs args)
        {
        }

        private void CoreWindowOnKeyDown(CoreWindow sender, KeyEventArgs args)
        {
            if (args.VirtualKey == VirtualKey.Down)
            {
                // ((TestViewModel)this.DataContext).TestClearCmd.Execute(null);
            }
            if (args.VirtualKey == VirtualKey.Up)
            {
                // ((TestViewModel)this.DataContext).TestBallsCmd.Execute(null);
            }

        }

        private void theCanvas_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            double x = e.GetCurrentPoint(theCanvas).Position.X;
            double y = e.GetCurrentPoint(theCanvas).Position.Y;
            double z = x + y;
        }

        private void theCanvas_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            // int a = 2;
        }
    }
}
