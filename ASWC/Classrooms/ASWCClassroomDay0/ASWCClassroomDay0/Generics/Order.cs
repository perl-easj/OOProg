namespace ASWCClassroomDay0.Generics
{
    public class Order
    {
        public int Id { get; set; }
        public string Desc { get; set; }

        public Order(string desc, int id)
        {
            Desc = desc;
            Id = id;
        }
    }
}