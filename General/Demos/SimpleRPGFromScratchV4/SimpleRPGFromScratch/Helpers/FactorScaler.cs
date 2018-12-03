namespace SimpleRPGFromScratch.Helpers
{
    // TODO - Kommentarer
    public class FactorScaler : Scaler<int>
    {
        private int _factor;

        public FactorScaler(int factor) : base(null, (a, b) => a < b)
        {
            _factor = factor;
        }

        public override int ScaleToValue(int index)
        {
            return index * _factor;
        }

        public override int ValueToScale(int val)
        {
            return val / _factor;
        }
    }
}