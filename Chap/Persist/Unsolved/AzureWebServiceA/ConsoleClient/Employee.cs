using System;

namespace ConsoleClient
{
    public class Employee
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Title { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime EmployedDate { get; set; }

        public int ImageKey { get; set; }

        public int CarsSold { get; set; }

        public override string ToString()
        {
            return $"{FullName.TrimEnd(' ')}, employed {EmployedDate.ToShortDateString()}";
        }
    }
}
