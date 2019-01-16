using ReportTool.NewClasses.Formatters.Interfaces;

namespace ReportTool.NewClasses.Formatters.Utility
{
    /// <summary>
    /// Specific strategy for text element formatting.
    /// The text element will be formatted by right-padding
    /// it with a number of spaces.
    /// </summary>
    public class TextElementPadRight : ITextElementFormatter
    {
        private string _text;
        private int _length;
        private char _padChar;

        public TextElementPadRight(string text, int length, char padChar = ' ')
        {
            _text = text;
            _length = length;
            _padChar = padChar;
        }

        public string FormattedText
        {
            get { return _text.PadRight(_length, _padChar); }
        }
    }
}