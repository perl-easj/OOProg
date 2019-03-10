namespace FOOrrestGump.FGScenarioChanged
{
    /// <summary>
    /// A Factory-like class for generating a ForrestGump object.
    /// CHANGED: Now generates ForrestGumpChanged objects
    /// </summary>
    public class ForrestGumpGeneratorChanged
    {
        public ForrestGumpChanged GenerateForrestGump()
        {
            return new ForrestGumpChanged();
        }
    }
}