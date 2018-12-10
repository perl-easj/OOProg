using System;
using SimpleRPGFromScratch.Helpers;

namespace SimpleRPGFromScratch.ViewModel.Control
{
    // TODO - Kommentarer
    public class SliderDataViewModel<TValue>
    {
        #region Instance fields
        private Scaler<TValue> _valueScaler;
        private int _sliderScaleMax;
        private Func<TValue> _callBackGetValue;
        private Action<TValue> _callBackSetValue;
        private Func<TValue, bool> _callBackCheckValue;
        #endregion

        #region Constructor
        public SliderDataViewModel(
            Scaler<TValue> valueScaler,
            int sliderScaleMax,
            Func<TValue> callBackGetValue,
            Action<TValue> callBackSetValue)
        : this (valueScaler, 
                sliderScaleMax, 
                callBackGetValue, 
                callBackSetValue,
                v => true)
        {
        }

        public SliderDataViewModel(
            Scaler<TValue> valueScaler,
            int sliderScaleMax,
            Func<TValue> callBackGetValue,
            Action<TValue> callBackSetValue,
            Func<TValue, bool> callBackCheckValue)
        {
            _valueScaler = valueScaler;
            _sliderScaleMax = sliderScaleMax;
            _callBackSetValue = callBackSetValue;
            _callBackGetValue = callBackGetValue;
            _callBackCheckValue = callBackCheckValue;
        }
        #endregion

        #region Properties til (indirekte) Data Binding
        public int SliderIndex
        {
            get { return _valueScaler.ValueToScale(_callBackGetValue()); }
            set
            {
                if (_callBackCheckValue(_valueScaler.ScaleToValue(value)))
                {
                    _callBackSetValue(_valueScaler.ScaleToValue(value));
                }
            }
        }

        public string SliderText
        {
            get { return _callBackGetValue().ToString(); }
        }

        public int SliderScaleMax
        {
            get { return _sliderScaleMax; }
        } 
        #endregion
    }
}