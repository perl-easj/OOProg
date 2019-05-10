namespace EFToolsDemo23NOV
{
    public partial class RarityTier
    {
        public double DamageFactor
        {
            get { return (Id * 1.0) / 100; }
        }
    }
}