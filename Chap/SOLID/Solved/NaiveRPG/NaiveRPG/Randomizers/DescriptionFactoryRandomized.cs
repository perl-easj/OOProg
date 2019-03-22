namespace NaiveRPG.Factories
{
    public class DescriptionFactoryRandomized : RandomizedFactory<string>
    {
        public DescriptionFactoryRandomized()
        {
            AddFactoryMethod(20, () => "Worn");
            AddFactoryMethod(25, () => "Plain");
            AddFactoryMethod(25, () => "Nice");
            AddFactoryMethod(30, () => "Shiny");
        }
    }
}