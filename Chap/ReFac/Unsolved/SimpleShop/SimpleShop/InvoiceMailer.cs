using System;
// ReSharper disable ReplaceWithSingleAssignment.True

namespace SimpleShop
{
    public class InvoiceMailer
    {
        public static string SendInvoice(string email, double amount, string description)
        {
            string text = $"Invoice to {email} for {amount} kr.\n" + description;
            return SendEmail(email, text);
        }

        private static string SendEmail(string email, string text)
        {
            bool validEmail = true;

            if (!email.Contains("@"))
            {
                validEmail = false;
            }

            if (!email.Contains("."))
            {
                validEmail = false;
            }

            int indexOfAt = email.IndexOf('@');
            int indexOfDot = email.IndexOf('.');

            if (indexOfAt > indexOfDot)
            {
                validEmail = false;
            }

            if (!validEmail)
            {
                throw new ArgumentException($"Email {email} is not a valid email address");
            }

            // Simulates actual sending of email....
            string emailSent = $"Email sent to {email}:\n";
            emailSent += "---------------------------------------\n";
            emailSent += text + "\n";

            return emailSent;
        }
    }
}