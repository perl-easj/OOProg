using System;
using System.Collections.Generic;
using Windows.UI;

namespace SimpleRPGFromScratch.Helpers
{
    public class ColorMapperIntervals<TValue> : ColorMapperBase<TValue>
    {
        private List<TValue> _intervalEnds;
        private List<Color> _colors;
        private Func<TValue, TValue, bool> _lessFunc;

        public ColorMapperIntervals(List<TValue> values, List<Color> colors, Func<TValue, TValue, bool> lessFunc)
        {
            if (values == null || colors == null || (values.Count + 1) != colors.Count)
            {
                throw new ArgumentException("ColorMapper");
            }

            _intervalEnds = values;
            _colors = colors;
            _lessFunc = lessFunc;
        }

        public override Color ValueToColor(TValue val)
        {
            int index = 0;

            while (_lessFunc(_intervalEnds[index], val))
            {
                index++;
            }

            return _colors[index];
        }
    }
}