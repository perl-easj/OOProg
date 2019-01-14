using System;
using Windows.UI;

namespace SimpleRPGFromScratch.Helpers
{
    public abstract class ColorMapperBase<TValue> : IColorMapper<TValue>
    {
        public abstract Color ValueToColor(TValue val);

        public virtual TValue ColorToValue(Color aColor)
        {
            throw new NotImplementedException("No meaningful conversion available");
        }
    }
}