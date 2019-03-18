namespace NaiveRPG.Factories
{
    public class QualityFactoryRandomizedNormal : RandomizedFactory<Quality>
    {
        public QualityFactoryRandomizedNormal()
        {
            AddFactoryMethod(1, () => Quality.masterwork);
            AddFactoryMethod(5, () => Quality.epic);
            AddFactoryMethod(24, () => Quality.rare);
            AddFactoryMethod(70, () => Quality.common);
        }
    }
}