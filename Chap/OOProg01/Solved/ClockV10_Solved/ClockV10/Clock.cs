namespace ClockV10
{
    public class Clock
    {
        #region Instance fields
        private int _minutesSince0000;
        #endregion

        #region Constructors
        public Clock(int hours, int minutes)
        {
            SetTime(hours, minutes);
        }

        public Clock()
        {
            SetTime(0, 0);
        }
        #endregion

        #region Properties
        public int Minutes
        {
            get { return _minutesSince0000 % 60; }
        }

        public int Hours
        {
            get { return _minutesSince0000 / 60; }
        }

        public string Display
        {
            get { return $"{Hours:00}:{Minutes:00}"; }
        }
        #endregion

        #region Methods
        public void SetTime(int hours, int minutes)
        {
            _minutesSince0000 = (hours * 60) + minutes;
        }

        public void AdvanceOneMinute()
        {
            _minutesSince0000 = (_minutesSince0000 + 1) % 1440;
        } 
        #endregion
    }
}