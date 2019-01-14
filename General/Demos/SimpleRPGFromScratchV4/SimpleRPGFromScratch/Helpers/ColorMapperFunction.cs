using System;
using Windows.UI;

namespace SimpleRPGFromScratch.Helpers
{
    public class ColorMapperFunction<TValue> : ColorMapperBase<TValue>
    {
        private Func<TValue, byte> _aMapFunc;
        private Func<TValue, byte> _rMapFunc;
        private Func<TValue, byte> _gMapFunc;
        private Func<TValue, byte> _bMapFunc;

        public ColorMapperFunction(
            Func<TValue, byte> aMapFunc, 
            Func<TValue, byte> rMapFunc, 
            Func<TValue, byte> gMapFunc, 
            Func<TValue, byte> bMapFunc)
        {
            _aMapFunc = aMapFunc;
            _rMapFunc = rMapFunc;
            _gMapFunc = gMapFunc;
            _bMapFunc = bMapFunc;
        }

        public override Color ValueToColor(TValue val)
        {
            return Color.FromArgb(_aMapFunc(val),_rMapFunc(val), _gMapFunc(val), _bMapFunc(val));
        }
    }
}