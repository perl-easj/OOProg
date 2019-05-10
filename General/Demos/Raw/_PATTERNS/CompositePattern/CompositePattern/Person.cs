using System.Collections;
using System.Collections.Generic;
using CompositePattern.CompositeLibrary;

namespace CompositePattern
{
    public class Person : CompositeAcceptorBase<Person>, IEnumerable<Person>
    {
        public string Name { get; }
        public int Funds { get; }

        public Person(string name, int funds)
        {
            Name = name;
            Funds = funds;
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public int FamilyTreeSize()
        {
            int size = 0;
            ApplyOperation(p => { size++; });
            return size;
        }

        public int FamilyFunds()
        {
            int totalFunds = 0;
            ApplyOperation(p => { totalFunds += ((Person)p).Funds; });
            return totalFunds;
        }

        public virtual IEnumerator<Person> GetEnumerator()
        {
            List<Person> persons = new List<Person>();
            ApplyOperation(p => persons.Add((Person)p));
            return persons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}