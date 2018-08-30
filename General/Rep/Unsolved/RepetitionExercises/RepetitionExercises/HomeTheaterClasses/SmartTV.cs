namespace RepetitionExercises
{
    // Denne klasse modellerer et (meget simpelt) Smart TV,
    // der kan tændes og slukkes, og hvor man kan skifte kanal.
    public class SmartTV
    {
        private const int MinChannel = 1;
        private const int MaxChannel = 100;

        private bool _isOn;
        private int _channel;

        public SmartTV()
        {
            _isOn = false;
            _channel = 0;
        }

        public bool IsOn
        {
            get { return _isOn; }
        }

        // Skift kanal, med mindre den nye værdi er
        // ulovlig, jf. min- og max-værdier for kanal.
        public int Channel
        {
            get { return _channel; }
            set
            {
                if (value >= MinChannel && value <= MaxChannel && IsOn)
                {
                    _channel = value;
                }
            }
        }

        // Skift mellem tændt og slukket tilstand.
        // Når TVet slukkes, stilles det på kanal 0.
        // Når TVet tændes, stilles det på kanal 1.
        public void ToggleOnOff()
        {
            _isOn = !_isOn;

            if (_isOn)
            {
                _channel = 1;
            }
            if (!_isOn)
            {
                _channel = 0;
            }
        }
    }
}