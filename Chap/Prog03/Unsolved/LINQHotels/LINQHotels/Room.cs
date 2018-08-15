namespace LINQHotels
{
    /// <summary>
    /// A class representing a hotel room. A hotel room has
    /// 1) A number
    /// 2) A hotel ID
    /// 3) A type ("D": Double, "F": Family, S:"Single")
    /// 4) A price
    /// </summary>
    public class Room
    {
        #region Instance fields
        private int _no;
        private int _hotelID;
        private string _type;
        private int _price;
        #endregion

        #region Constructor
        public Room(int no, int hotelID, string type, int price)
        {
            _no = no;
            _hotelID = hotelID;
            _type = type;
            _price = price;
        }
        #endregion

        #region Properties
        public int No
        {
            get { return _no; }
        }

        public int HotelID
        {
            get { return _hotelID; }
        }

        public string Type
        {
            get { return _type; }
        }

        public int Price
        {
            get { return _price; }
        } 
        #endregion

        public override string ToString()
        {
            return $"HotelNo: {HotelID}, No: {No}, Type: {Type}, Price: {Price}";
        }
    }
}