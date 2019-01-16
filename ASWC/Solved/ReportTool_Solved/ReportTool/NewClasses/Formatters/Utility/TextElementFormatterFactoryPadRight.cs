using ReportTool.NewClasses.Formatters.Interfaces;

namespace ReportTool.NewClasses.Formatters.Utility
{
    public class TextElementFormatterFactoryPadRight : ITextElementFormatterFactory
    {
        public ITextElementFormatter Create(string text, int width = 0)
        {
            return new TextElementPadRight(text, width);
        }
    }
}