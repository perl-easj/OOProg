using System;
using SimpleRPGFromScratch.Helpers;

namespace SimpleRPGFromScratch.ViewModel.Control
{
    // TODO - Kommentarer
    public class IntSliderDataViewModel : SliderDataViewModel<int>
    {
        public IntSliderDataViewModel(
            int valueMax, 
            int sliderScaleFactor,
            Func<int> callBackGetValue, 
            Action<int> callBackSetValue) 
            : base(new FactorScaler(sliderScaleFactor), valueMax / sliderScaleFactor, callBackGetValue, callBackSetValue)
        {
        }

        public IntSliderDataViewModel(
            int valueMax,
            Func<int> callBackGetValue,
            Action<int> callBackSetValue)
            : base(new IdentityScaler(), valueMax, callBackGetValue, callBackSetValue)
        {
        }
    }
}