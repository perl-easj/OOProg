using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace AddOns.UI.Implementation
{
    /// <summary>
    /// Simple class for presenting a dialog for the user, and return a value
    /// to the caller of PresentDialogWithReturnValue.
    /// </summary>
    public class DialogWithReturnValue
    {
        public enum ReturnValueType
        {
            Undefined,
            OK,
            Cancel
        }

        public static async Task<ReturnValueType> PresentDialogWithReturnValue(string message, string confirmText = "OK")
        {
            ReturnValueType retVal = ReturnValueType.Undefined;

            var messageDialog = new MessageDialog(message);
            messageDialog.Commands.Add(new UICommand(confirmText, command => { retVal = ReturnValueType.OK; }));
            messageDialog.Commands.Add(new UICommand("Cancel", command => { retVal = ReturnValueType.Cancel; }));
            messageDialog.DefaultCommandIndex = 1;
            messageDialog.CancelCommandIndex = 1;
            await messageDialog.ShowAsync();

            return retVal;
        }
    }
}