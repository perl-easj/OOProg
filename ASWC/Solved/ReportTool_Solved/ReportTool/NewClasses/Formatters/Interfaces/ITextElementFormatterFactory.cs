namespace ReportTool.NewClasses.Formatters.Interfaces
{
    public interface ITextElementFormatterFactory
    {
        ITextElementFormatter Create(string text, int width = 0);
    }
}