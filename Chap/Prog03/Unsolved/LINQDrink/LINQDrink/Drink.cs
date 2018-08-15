namespace LINQDrink
{
    /// <summary>
    /// This class represents a simple drink, which consists of
    /// 1) An alcoholic part (name and amount in cl.)
    /// 2) A non-alcoholic part (name and amount in cl.)
    /// </summary>
    public class Drink
    {
        #region Instance fields
        private string _name;

        private string _alcoholicPart;
        private string _nonAlcoholicPart;

        private int _alcoholicPartAmount;
        private int _nonAlcoholicPartAmount;
        #endregion

        #region Constructor
        public Drink(string name,
            string alcoholicPart, int alcoholicPartAmount,
            string nonAlcoholicPart, int nonAlcoholicPartAmount)
        {
            _name = name;

            _alcoholicPart = alcoholicPart;
            _alcoholicPartAmount = alcoholicPartAmount;

            _nonAlcoholicPart = nonAlcoholicPart;
            _nonAlcoholicPartAmount = nonAlcoholicPartAmount;
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
        }

        public string AlcoholicPart
        {
            get { return _alcoholicPart; }
        }

        public string NonAlcoholicPart
        {
            get { return _nonAlcoholicPart; }
        }

        public int AlcoholicPartAmount
        {
            get { return _alcoholicPartAmount; }
        }

        public int NonAlcoholicPartAmount
        {
            get { return _nonAlcoholicPartAmount; }
        }
        #endregion
    }
}