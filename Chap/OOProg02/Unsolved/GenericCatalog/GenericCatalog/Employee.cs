namespace GenericCatalog
{
    public class Employee
    {
        public Employee(string name, int yearOfBirth)
        {
            Name = name;
            YearOfBirth = yearOfBirth;
        }

        public string Name { get; set; }
        public int YearOfBirth { get; set; }

        public override string ToString()
        {
            return $"{Name}, born {YearOfBirth}";
        }
    }
}