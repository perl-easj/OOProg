using System;
using Windows.UI.Xaml.Controls;

namespace ViewModel.Flow.Implementation
{
    public class FlowViewModelEnd<T> : FlowViewModelBase<T> 
        where T : new()
    {
        public FlowViewModelEnd(Frame frame, Type backPageType, Func<bool> canNavigateBackFunc) 
            : base(frame, backPageType, null, canNavigateBackFunc, () => false)
        {
        }

        public FlowViewModelEnd(Frame frame, Type backPageType) 
            : base(frame, backPageType, null)
        {
        }
    }
}