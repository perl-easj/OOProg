using System;
using Windows.UI.Xaml.Controls;

namespace ViewModel.Flow.Implementation
{
    public class FlowViewModelEnd<TData> : FlowViewModelBase<TData> 
        where TData : new()
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