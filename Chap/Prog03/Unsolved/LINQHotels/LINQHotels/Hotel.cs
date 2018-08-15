namespace LINQHotels
{
    /// <summary>
    /// A simple class representing a hotel. A hotel has a
    /// unique ID, plus a name and an adresss
    /// </summary>
    public class Hotel
    {
        #region Instance fields
        private int _id;
        private string _name;
        private string _address;
        #endregion

        #region Constructor
        public Hotel(int id, string name, string address)
        {
            _id = id;
            _name = name;
            _address = address;
        }
        #endregion

        #region Properties
        public int ID
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Address
        {
            get { return _address; }
        } 
        #endregion

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Address: {Address}";
        }
    }
}