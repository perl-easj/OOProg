namespace FOOrrestGump.FGScenarioChanged
{
    /// <summary>
    /// A Factory-like class for generating a ChocolateBox object.
    /// CHANGED: Now generates ChocolateBoxChanged objects
    /// </summary>
    public class ChocolateBoxGeneratorChanged
    {
        private ChocolateGeneratorChanged _chocolateGenerator;

        public ChocolateBoxGeneratorChanged()
        {
            _chocolateGenerator = new ChocolateGeneratorChanged();
        }

        public ChocolateBoxChanged GenerateChocolateBox(int noOfChocolates = 20)
        {
            ChocolateBoxChanged box = new ChocolateBoxChanged();

            for (int i = 0; i < noOfChocolates; i++)
            {
                box.AddChocolate(_chocolateGenerator.GenerateChocolate());
            }

            return box;
        }
    }
}