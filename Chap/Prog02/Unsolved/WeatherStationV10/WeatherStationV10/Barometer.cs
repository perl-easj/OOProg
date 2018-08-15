namespace WeatherStationV10
{
    /// <summary>
    ///  Simple barometer, measuring pressure in hPa (hectopascal)
    /// </summary>
    public class Barometer
    {
        #region Instance fields
        private double _pressureInHPa;
        #endregion

        #region Constructor
        public Barometer()
        {
            _pressureInHPa = 1000.0;
        }
        #endregion

        #region Properties
        public double Pressure
        {
            get { return _pressureInHPa; }
            set { _pressureInHPa = value; }
        }

        public string WeatherDescription
        {
            get { return "All weather is nice!"; }
        }
        #endregion
    }
}