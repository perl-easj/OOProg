using System;
using System.Collections.Generic;
// ReSharper disable ReplaceWithSingleAssignment.True

namespace SimpleShop
{
    public class Order
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; }
        public string Email { get; }
        public Dictionary<int, int> OrderLines;

        public Order(string firstName, string lastName, string address, string email)
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


            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;

            OrderLines = new Dictionary<int, int>();
        }

        public void AddOrderLine(int productId, int quantity)
        {
            OrderLines[productId] = quantity;
        }
    }
}