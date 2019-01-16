namespace ReportTool.DomainClasses
{
    /// <summary>
    /// Simple domain class representing a customer.
    /// </summary>
    public class Customer
    {
        #region Properties
        public int CustomerId { get; }
        public string Name { get; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        #endregion

        #region Constructor
        public Customer(int customerId, string name, string address, int zipCode)
        {
            CustomerId = customerId;
            Name = name;
            Address = address;
            ZipCode = zipCode;
        } 
        #endregion
    }
}