namespace RepetitionExercises
{
    // Denne klasse skal agere base-klasse for "devices",
    // som kan indgå i et HT-system.
    public class HomeTheaterDevice : IHomeTheaterDevice
    {
        private bool _isOn;

        public HomeTheaterDevice()
        {
            _isOn = false;
        }

        public bool IsOn
        {
            get { return _isOn; }
        }

        // Skift mellem tændt og slukket tilstand.
        // Hvis der slukkes, udføres HandleOff().
        // Hvis der tændes, udføres HandleOn().
        public void ToggleOnOff()
        {
            _isOn = !_isOn;

            if (_isOn)
            {
                HandleOn();
            }
            else
            {
                HandleOff();
            }
        }

        protected virtual void HandleOn()
        {
        }

        protected virtual void HandleOff()
        {
        }
    }
}