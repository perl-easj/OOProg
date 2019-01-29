namespace ASWCClassroomDay0.Generics
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}