using System;
using CarRetailDemo.Data.Base;
using CarRetailDemo.Models.App;

namespace CarRetailDemo.Data.Domain
{
    public class Employee : DomainClassAppBase
    {
        public Employee(int key, int imageKey, string fullName, string phone, string email, string title, DateTime employedDate)
            : base(imageKey)
        {
            Key = key;
            FullName = fullName;
            Phone = phone;
            Email = email;
            Title = title;
            EmployedDate = employedDate;
        }

        public Employee() : base(NullKey)
        {
        }

        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public DateTime EmployedDate { get; set; }

        public override void SetDefaultValues()
        {
            Key = NullKey;
            ImageKey = NullKey;
            FullName = "(not set)";
            Phone = "(not set)";
            Email = "(not set)";
            Title = "(not set)";
            EmployedDate = DateTimeOffset.Now.Date;
        }

        public int CarsSold
        {
            get { return DomainModel.Instance.CarsSoldByEmployee(Key); }
            set { }
        }
    }
}