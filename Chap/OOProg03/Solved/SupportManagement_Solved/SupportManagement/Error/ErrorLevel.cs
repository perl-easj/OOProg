namespace SupportManagement.Error
{
    /// <summary>
    /// Level of criticality for errors.
    /// When an error is solved, level is set to Solved.
    /// </summary>
    public enum ErrorLevel
    {
        Light,
        Moderate,
        Severe,
        Catastrophic,
        Solved
    }
}