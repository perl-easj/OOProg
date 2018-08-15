using System;
using SupportManagement.Error;
using SupportManagement.SupportCommon;
using SupportManagement.SupportCoR;
using SupportManagement.SupportCoR.Config;
using SupportManagement.SupportOriginal;

namespace SupportManagement
{
    /// <summary>
    /// Class for invoking a test of the support center implementations.
    /// </summary>
    public class SupportCenterTest
    {
        public static void Run()
        {
            Console.WriteLine("Test of SupportCenterOriginal...");
            TestSupportCenter(new SupportCenterOriginal());

            Console.WriteLine("Test of SupportCenterCoR...");
            TestSupportCenter(new SupportCenterCoR(new SupportCoRConfigurationDefault()));
        }

        private static void TestSupportCenter(ISupportCenter supportCenter)
        {
            supportCenter.Reset();

            supportCenter.SubmitTicket(new ErrorTicket("Window too small", "", ErrorLanguage.English, ErrorLevel.Moderate));
            supportCenter.SubmitTicket(new ErrorTicket("Slow after few minutes", "", ErrorLanguage.English, ErrorLevel.Severe));
            supportCenter.SubmitTicket(new ErrorTicket("Kan ikke gemme", "", ErrorLanguage.Danish, ErrorLevel.Severe));
            supportCenter.SubmitTicket(new ErrorTicket("Underlig farve i baggrund", "", ErrorLanguage.Danish, ErrorLevel.Light));
            supportCenter.SubmitTicket(new ErrorTicket("Kan ikke starte på Win8", "", ErrorLanguage.Danish, ErrorLevel.Catastrophic));
            supportCenter.SubmitTicket(new ErrorTicket("Freezes if minimised", "", ErrorLanguage.English, ErrorLevel.Catastrophic));
            supportCenter.SubmitTicket(new ErrorTicket("Mangler hjælpetekst", "", ErrorLanguage.Danish, ErrorLevel.Moderate));
            supportCenter.SubmitTicket(new ErrorTicket("Spelling errors in help text", "", ErrorLanguage.English, ErrorLevel.Light));
            supportCenter.SubmitTicket(new ErrorTicket("No help text to conversion", "", ErrorLanguage.English, ErrorLevel.Severe));
            supportCenter.SubmitTicket(new ErrorTicket("Tabstop rækkefølge ikke rigtig", "", ErrorLanguage.Danish, ErrorLevel.Light));

            Console.WriteLine("Before handling:");
            Console.WriteLine($"Open tickets     : {supportCenter.OpenTicketCount}");
            Console.WriteLine($"Closed tickets   : {supportCenter.ClosedTicketCount}");
            Console.WriteLine($"Unhandled tickets: {supportCenter.UnhandledTicketCount}");
            Console.WriteLine();

            supportCenter.HandleOpenTickets();

            Console.WriteLine("After handling:");
            Console.WriteLine($"Open tickets     : {supportCenter.OpenTicketCount}");
            Console.WriteLine($"Closed tickets   : {supportCenter.ClosedTicketCount}");
            Console.WriteLine($"Unhandled tickets: {supportCenter.UnhandledTicketCount}");
            Console.WriteLine();
        }
    }
}