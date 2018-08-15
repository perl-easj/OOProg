using System;
using Windows.UI.Popups;
#pragma warning disable CS4014

namespace NoteBook
{
    public class NoteErrorPresenter
    {
        public static void ReportExistingTitle(string title, Action undo)
        {
            var messageDialog = new MessageDialog("Add Note");
            messageDialog.Content = "A note with the title " + title + " already exists!\n" + "Please use a different title.";
            messageDialog.Commands.Add(new UICommand("OK", command => { undo(); }));
            messageDialog.ShowAsync();
        }
    }
}