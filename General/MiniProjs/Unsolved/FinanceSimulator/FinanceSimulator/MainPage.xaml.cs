using System.Diagnostics;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FinanceSimulator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            StockSimulationModel ssm = new StockSimulationModel();

            ssm.QuoteGenerator.Quotes += q =>
            {
                Debug.WriteLine($"Got quote: {q.FiID}@{q.Price:F2}");
            };

            ssm.Start();
        }
    }
}
