namespace FOOrrestGump.FGScenario
{
    /// <summary>
    /// A Factory-like class for generating a ChocolateBox object.
    /// </summary>
    public class ChocolateBoxGenerator
    {
        private ChocolateGenerator _chocolateGenerator;

        public ChocolateBoxGenerator()
        {
            _chocolateGenerator = new ChocolateGenerator();
        }

        public ChocolateBox GenerateChocolateBox(int noOfChocolates = 20)
        {
            ChocolateBox box = new ChocolateBox();

            for (int i = 0; i < noOfChocolates; i++)
            {
                box.AddChocolate(_chocolateGenerator.GenerateChocolate());
            }

            return box;
        }
    }
}