namespace ModernFamily
{
    /// <summary>
    /// Fairly simplistic representation of an individual
    /// </summary>
    public class Person
    {
        #region Properties
        public string Name { get; }
        public int Age { get; }
        public bool Gender { get; }
        #endregion

        #region Constructor
        public Person(string name, int age, bool gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        } 
        #endregion

        public override string ToString()
        {
            return $"{Name}, {Age} years old {(Gender ? "male" : "female")}";
        }
    }
}