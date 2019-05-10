using Windows.UI.Xaml.Controls;

namespace Canvas01
{
    public class MainCanvas
    {
        private static MainCanvas _instance;
        private static int _nextID = 0;

        public Canvas TheCanvas { get; set; }

        public static MainCanvas Instance
        {
            get
            {
                _instance = _instance ?? new MainCanvas();
                return _instance;
            }
        }

        public static int NextID
        {
            get { return _nextID++; }
        }

        private MainCanvas()
        {
        }
    }
}