namespace NaiveRPG.Factories
{
    public class ColorFactoryRandomized : RandomizedFactory<string>
    {
        public ColorFactoryRandomized()
        {
            AddFactoryMethod(10, () => "Black");
            AddFactoryMethod(20, () => "Brown");
            AddFactoryMethod(30, () => "Red");
            AddFactoryMethod(40, () => "Green");
        }
    }
}