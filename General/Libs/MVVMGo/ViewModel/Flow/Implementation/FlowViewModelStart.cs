using System;
using Windows.UI.Xaml.Controls;

namespace ViewModel.Flow.Implementation
{
    public class FlowViewModelStart<T> : FlowViewModelBase<T> 
        where T : new()
    {
        public FlowViewModelStart(Frame frame, Type forwardPageType, Func<bool> canNavigateForwardFunc) 
            : base(frame, null, forwardPageType, () => false, canNavigateForwardFunc)
        {
        }

        public FlowViewModelStart(Frame frame, Type forwardPageType) 
            : base(frame, null, forwardPageType)
        {
        }
    }
}