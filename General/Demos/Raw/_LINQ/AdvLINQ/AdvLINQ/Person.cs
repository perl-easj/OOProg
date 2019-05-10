using System.Collections.Generic;

namespace AdvLINQ
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
            Contacts = new List<Person>();
        }

        public string Name{ get; set; }
        public List<Person> Contacts { get; set; }
    }
}