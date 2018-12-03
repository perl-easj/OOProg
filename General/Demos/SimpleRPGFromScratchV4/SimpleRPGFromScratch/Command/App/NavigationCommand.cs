using System;
using Windows.UI.Xaml.Controls;
using SimpleRPGFromScratch.Command.Base;

namespace SimpleRPGFromScratch.Command.App
{
    /// <summary>
    /// En Command-klasse specifikt til at udføre navigation.
    /// </summary>
    public class NavigationCommand : CommandBase
    {
        private Frame _frame;
        private Type _pageType;
        private Func<bool> _canNavigateFunc;

        public NavigationCommand(Frame frame, Type pageType, Func<bool> canNavigateFunc)
        {
            _frame = frame;
            _pageType = pageType;
            _canNavigateFunc = canNavigateFunc;
        }

        public NavigationCommand(Frame frame, Type pageType)
            : this(frame, pageType, () => true)
        {
        }

        /// <summary>
        /// Navigation kan udføres, hvis funktionen medgivet som parameter
        /// til constructoren evaluerer til true.
        /// </summary>
        protected override bool CanExecute()
        {
            return _canNavigateFunc.Invoke();
        }

        /// <summary>
        /// Udfører selve navigationen til det View, som blev angivet
        /// som parameter til constructoren.
        /// </summary>
        protected override void Execute()
        {
            _frame.Navigate(_pageType);
        }
    }
}