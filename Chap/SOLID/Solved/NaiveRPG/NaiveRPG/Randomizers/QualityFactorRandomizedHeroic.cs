namespace NaiveRPG.Factories
{
    public class QualityFactorRandomizedHeroic : RandomizedFactory<Quality>
    {
        public QualityFactorRandomizedHeroic()
        {
            AddFactoryMethod(2, () => Quality.masterwork);
            AddFactoryMethod(8, () => Quality.epic);
            AddFactoryMethod(40, () => Quality.rare);
            AddFactoryMethod(50, () => Quality.common);
        }
    }
}