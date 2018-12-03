namespace SimpleRPGFromScratch.Helpers
{
    // TODO - Kommentarer
    public class IdentityScaler : Scaler<int>
    {
        public IdentityScaler() : base(null, (a, b) => a < b)
        {
        }

        public override int ScaleToValue(int index)
        {
            return index;
        }

        public override int ValueToScale(int val)
        {
            return val;
        }
    }
}