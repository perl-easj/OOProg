using Windows.UI;

namespace SimpleRPGFromScratch.Helpers
{
    public interface IColorMapper<TValue>
    {
        Color ValueToColor(TValue val);
        TValue ColorToValue(Color aColor);
    }
}