using System;
using System.Collections.Generic;
using Windows.UI;

namespace SimpleRPGFromScratch.Helpers
{
    public class ColorMapperValues<TValue> : ColorMapperBase<TValue>
    {
        private Dictionary<TValue, Color> _colorMap;
        private Color DefaultColor = Colors.White;

        public ColorMapperValues(List<TValue> values, List<Color> colors)
        {
            if (values == null || colors == null || values.Count != colors.Count)
            {
                throw new ArgumentException("ColorMapper");
            }

            _colorMap = new Dictionary<TValue, Color>();
            for (int i = 0; i < values.Count; i++)
            {
                _colorMap.Add(values[i], colors[i]);
            }
        }

        public override Color ValueToColor(TValue val)
        {
            return _colorMap.ContainsKey(val) ? _colorMap[val] : DefaultColor;
        }
    }
}