using System;

namespace SOLID.Liskov
{
    public class Name
    {
        public string Value { get; }

        public Name(string value)
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Names must " +
                    "be at least three characters long.");
            }

            Value = value;
        }
    }
}