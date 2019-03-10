namespace FOOrrestGump.FGScenario
{
    /// <summary>
    /// A Factory-like class for generating a ForrestGump object.
    /// </summary>
    public class ForrestGumpGenerator
    {
        public ForrestGump GenerateForrestGump()
        {
            return new ForrestGump();
        }
    }
}