namespace SimpleShop.Util
{
    public class InvoiceMailer
    {
        public static string SendInvoice(string email, double amount, string description)
        {
            // Might be called in different context than with a (verified)
            // Email from a Customer object...
            Email.CheckEmail(email);

            string text = $"Invoice to {email} for {amount} kr.\n" + description;
            return SendEmail(email, text);
        }

        private static string SendEmail(string email, string text)
        {
            // Simulates actual sending of email....
            string emailSent = $"Email sent to {email}:\n";
            emailSent += "---------------------------------------\n";
            emailSent += text + "\n";

            return emailSent;
        }
    }
}