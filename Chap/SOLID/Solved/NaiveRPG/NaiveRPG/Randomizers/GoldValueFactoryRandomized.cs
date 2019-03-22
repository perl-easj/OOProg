namespace NaiveRPG.Factories
{
    public class GoldValueFactoryRandomized : IFactory<int>
    {
        private int _maxValue;

        public GoldValueFactoryRandomized(int maxValue = 100)
        {
            _maxValue = maxValue;
        }

        public int Create()
        {
            return (RandomUtil.Percentage() * _maxValue) / 100;
        }
    }
}