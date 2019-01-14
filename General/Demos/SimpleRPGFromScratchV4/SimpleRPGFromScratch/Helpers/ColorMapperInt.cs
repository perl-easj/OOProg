using System;
using Windows.UI;

namespace SimpleRPGFromScratch.Helpers
{
    public class ColorMapperInt : ColorMapperFunction<int>
    {
        private const int Power8 = 256;
        private const int Power16 = 256 * 256;
        private const int Power24 = 256 * 256 * 256;


        public ColorMapperInt(
            Func<int, byte> aMapFunc, 
            Func<int, byte> rMapFunc, 
            Func<int, byte> gMapFunc, 
            Func<int, byte> bMapFunc) 
            : base(aMapFunc, rMapFunc, gMapFunc, bMapFunc)
        {
        }

        public override int ColorToValue(Color aColor)
        {
            uint uVal = (uint) (aColor.A * Power24
                                + aColor.R * Power16
                                + aColor.G * Power8
                                + aColor.B);
            int val = (int)(uVal - Int32.MaxValue);
            return val;
        }


    }
}