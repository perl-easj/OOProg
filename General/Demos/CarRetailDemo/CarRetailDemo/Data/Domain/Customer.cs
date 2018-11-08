namespace MVVMStarterDemoA.Data.Domain
{
    public partial class Customer
    {
        public int Id { get; set; }
        public int ImageKey { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public bool NewsLetter { get; set; }
    }
}
