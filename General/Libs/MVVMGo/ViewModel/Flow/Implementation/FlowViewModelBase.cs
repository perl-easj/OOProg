using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Commands.Implementation;

// ReSharper disable NotAccessedField.Local

namespace ViewModel.Flow.Implementation
{
    public class FlowViewModelBase<TData> : INotifyPropertyChanged where TData : new()
    {
        public static TData FlowDataObject = new TData();

        private NavigationCommand _navigateBackCmd;
        private NavigationCommand _navigateForwardCmd;

        public FlowViewModelBase(Frame frame, Type backPageType, Type forwardPageType, Func<bool> canNavigateBackFunc, Func<bool> canNavigateForwardFunc)
        {
            _navigateBackCmd = new NavigationCommand(frame, backPageType, canNavigateBackFunc);
            _navigateForwardCmd = new NavigationCommand(frame, forwardPageType, canNavigateForwardFunc);
        }

        public FlowViewModelBase(Frame frame, Type backPageType, Type forwardPageType) 
            : this(frame, backPageType, forwardPageType, () => true, () => true)
        {
        }

        public ICommand NavigateBackCmd
        {
            get { return _navigateBackCmd; }
        }

        public ICommand NavigateForwardCmd
        {
            get { return _navigateForwardCmd; }
        }

        public static void ResetFlowDataObject()
        {
            FlowDataObject = new TData();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}