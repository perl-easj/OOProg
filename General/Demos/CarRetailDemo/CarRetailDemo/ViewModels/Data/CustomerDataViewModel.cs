using System;
using CarRetailDemo.ViewModels.Base;
using MVVMStarterDemoA.Data.Domain;

namespace CarRetailDemo.ViewModels.Data
{
    public class CustomerDataViewModel : DataViewModelAppBase<Customer>
    {
        public CustomerDataViewModel(Customer obj) : base(obj, "Customer")
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

        public string Address
        {
            get { return DataObject.Address.TrimEnd(' '); }
            set
            {
                DataObject.Address = value;
                OnPropertyChanged();
            }
        }

        public int ZipCode
        {
            get { return DataObject.ZipCode; }
            set
            {
                DataObject.ZipCode = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get { return DataObject.City.TrimEnd(' '); }
            set
            {
                DataObject.City = value;
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

        public int MinPrice
        {
            get { return DataObject.MinPrice; }
            set
            {
                DataObject.MinPrice = value;
                OnPropertyChanged();
            }
        }

        public int MaxPrice
        {
            get { return DataObject.MaxPrice; }
            set
            {
                DataObject.MaxPrice = value;
                OnPropertyChanged();
            }
        }

        public bool NewsLetter
        {
            get { return DataObject.NewsLetter; }
            set
            {
                DataObject.NewsLetter = value;
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
            get { return City; }
        }
    }
}