using System;
using CarRetailDemo.ViewModels.Base;
using MVVMStarterDemoA.Data.Domain;

namespace CarRetailDemo.ViewModels.Data
{
    public class EmployeeDataViewModel : DataViewModelAppBase<Employee>
    {
        public EmployeeDataViewModel(Employee obj) : base(obj, "Employee")
        {
        }

        public string Name
        {
            get { return DataObject.FullName.TrimEnd(' '); }
            set
            {
                DataObject.FullName = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return DataObject.Title.TrimEnd(' '); }
            set
            {
                DataObject.Title = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get { return DataObject.Phone.TrimEnd(' '); }
            set
            {
                DataObject.Phone = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return DataObject.Email.TrimEnd(' '); }
            set
            {
                DataObject.Email = value;
                OnPropertyChanged();
            }
        }

        public int CarsSold
        {
            get { return DataObject.CarsSold(); }
        }

        public DateTimeOffset Employed
        {
            get { return DataObject.EmployedDate; }
            set
            {
                DataObject.EmployedDate = value.Date;
                OnPropertyChanged();
            }
        }

        public override int ImageKey
        {
            get { return DataObject.ImageKey; }
            set
            {
                DataObject.ImageKey = value;
                OnPropertyChanged();
            }
        }

        public override string HeaderText
        {
            get
            {
                if (Name == null || !Name.Contains(" "))
                {
                    return Name;
                }
                else
                {
                    int index = Name.IndexOf(" ", StringComparison.Ordinal);
                    var shortName = Name.Substring(0, index + 1);
                    if (Name.Length > index + 1)
                    {
                        shortName += Name.Substring(index + 1, 1) + ".";
                    }
                    return shortName;
                }
            }
        }

        public override string ContentText
        {
            get { return Phone; }
        }
    }
}