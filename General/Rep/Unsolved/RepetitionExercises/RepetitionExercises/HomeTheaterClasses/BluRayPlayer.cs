namespace RepetitionExercises
{
    // Denne klasse modellerer en (meget simpel) Blu-Ray afspiller,
    // der kan tændes og slukkes, og hvor en afspilning kan startes
    // og stoppes
    public class BluRayPlayer
    {
        private bool _isOn;
        private bool _isPlaying;

        public BluRayPlayer()
        {
            _isOn = false;
            _isPlaying = false;
        }

        public bool IsOn
        {
            get { return _isOn; }
        }

        public bool IsPlaying
        {
            get { return _isPlaying; }
        }

        // Skift mellem tændt og slukket tilstand.
        // Hvis afspilleren slukkes, stilles den 
        // i Stop-tilstand.
        public void ToggleOnOff()
        {
            _isOn = !_isOn;

            if (!_isOn)
            {
                Stop();
            }
        }

        // Start afspilning. Kan kun foretages, hvis
        // afspilleren er tændt.
        public void Play()
        {
            if (IsOn)
            {
                _isPlaying = true;
            }
        }

        // Stop afspilning.
        public void Stop()
        {
            _isPlaying = false;
        }
    }
}