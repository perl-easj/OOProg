using System;
using System.Collections.Generic;

namespace SlotMachineDemo.Types
{
    /// <summary>
    /// Management of conversions between tick values 
    /// and corresponding scale values.
    /// </summary>
    public class TickScale
    {
        private readonly List<int> _scale;

        public TickScale(List<int> scale)
        {
            _scale = scale;
        }

        /// <summary>
        /// Converts the given tick value to a scale value.
        /// Out-of-range tick values will cause an exception
        /// </summary>
        public int TickToScale(int tickValue)
        {
            if (tickValue >= _scale.Count || tickValue < 0)
            {
                throw new ArgumentException(nameof(TickToScale));
            }

            return _scale[tickValue];
        }

        /// <summary>
        /// Converts the given scale value to a tick value.
        /// Values beyond first/last scale value will "snap"
        /// to first/last tick value.
        /// </summary>
        public int ScaleToTick(int scaleValue)
        {
            int tickValue = 0;

            while (scaleValue > _scale[tickValue] && tickValue < _scale.Count)
            {
                tickValue++;
            }

            return tickValue;
        }
    }
}
