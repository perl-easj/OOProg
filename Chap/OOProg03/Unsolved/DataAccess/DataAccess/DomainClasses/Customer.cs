namespace DataAccess.DomainClasses
{
    /// <summary>
    /// Domain class representing a customer. 
    /// This domain class does implement IHasKey.
    /// </summary>
    public class Customer : IHasKey
    {
        #region Instance fields
        private int _key;
        private string _name;
        private string _phone;
        #endregion

        #region Constructor
        public Customer(string name, string phone, int key)
        {
            _key = key;
            _name = name;
            _phone = phone;
        }
        #endregion

        #region Properties
        public int Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Phone
        {
            get { return _phone; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Customer: Key = {Key}, Name = {Name}, Phone = {Phone}";
        } 
        #endregion
    }
}