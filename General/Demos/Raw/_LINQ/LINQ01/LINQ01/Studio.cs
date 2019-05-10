namespace LINQ01
{
    public class Studio
    {
        private string _studioName;
        private string _HQCity;
        private int _noOfEmployees;

        public Studio(string studioName, string hqCity, int noOfEmployees)
        {
            _studioName = studioName;
            _HQCity = hqCity;
            _noOfEmployees = noOfEmployees;
        }

        public string StudioName
        {
            get { return _studioName; }
        }

        public string HqCity
        {
            get { return _HQCity; }
        }

        public int NoOfEmployees
        {
            get { return _noOfEmployees; }
        }

        public override string ToString()
        {
            return $"{StudioName}, HQ in {HqCity} ({NoOfEmployees} employees)";
        }
    }
}