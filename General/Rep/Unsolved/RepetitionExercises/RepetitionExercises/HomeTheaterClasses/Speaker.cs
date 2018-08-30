namespace RepetitionExercises
{
    // Denne klasse modellerer en højttaler, der kan tændes og slukkes,
    // og hvor man kan skrue op og ned for lysstyrken.
    public class Speaker
    {
        private const int MinVolume = 0;
        private const int MaxVolume = 100;

        private bool _isOn;
        private int _currentVolume;

        public Speaker()
        {
            _currentVolume = 0;
            _isOn = false;
        }

        public bool IsOn
        {
            get { return _isOn; }
        }

        public int CurrentVolume
        {
            get { return _currentVolume; }
        }

        // Skift mellem tændt og slukket tilstand.
        // Når højttaleren slukkes, sættes lydstyrken til 0.
        public void ToggleOnOff()
        {
            _isOn = !_isOn;

            if (!_isOn)
            {
                _currentVolume = 0;
            }
        }

        // Skru op for lydstyrken, med mindre vi har nået
        // den maksimale lydstyrke
        public void IncreaseVolume()
        {
            if (_currentVolume < MaxVolume && IsOn)
            {
                _currentVolume++;
            }
        }

        // Skru op for lydstyrken, med mindre vi har nået
        // den minimale lydstyrke
        public void DecreaseVolume()
        {
            if (_currentVolume > MinVolume && IsOn)
            {
                _currentVolume--;
            }
        } 
    }
}