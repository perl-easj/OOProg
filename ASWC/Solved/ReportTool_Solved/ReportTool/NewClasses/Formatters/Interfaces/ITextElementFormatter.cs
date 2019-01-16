namespace ReportTool.NewClasses.Formatters.Interfaces
{
    /// <summary>
    /// Objects implementing this interface will produce a properly formatted
    /// string when FormattedText is invoked. It can be perceived as a wrapper
    /// around a single (unformatted) text element. 
    /// </summary>
    public interface ITextElementFormatter
    {
        /// <summary>
        /// Returns properly formatted text element.
        /// </summary>
        string FormattedText { get; }
    }
}