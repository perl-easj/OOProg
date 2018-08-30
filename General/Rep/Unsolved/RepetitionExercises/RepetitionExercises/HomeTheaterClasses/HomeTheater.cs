namespace RepetitionExercises
{
    // Denne klasse definerer et Home Theater (HT) system. 
    // Dette er defineret som bestående af: 
    // Et TV, en Blu-Ray afspiller samt to højttalere.
    public class HomeTheater
    {
        public HomeTheater()
        {
        }

        // Skift mellem tændt og slukket tilstand for systemet.
        // Dette gøres ved at udføre denne operation på alle
        // devices i systemet.
        public void ToggleOnOff()
        {
        }

        // Skru op for lydstyrken i begge højttalere.
        public void IncreaseVolume()
        {
        }

        // Skru ned for lydstyrken i begge højttalere.
        public void DecreaseVolume()
        {
        }

        // Skift til næste kanal (kanal lige efter 
        // nuværende kanal) på TVet.
        public void IncreaseChannel()
        {
        }

        // Skift til forrige kanal (kanal lige før 
        // nuværende kanal) på TVet.
        public void DecreaseChannel()
        {
        }

        // Start afspilning på Blu-Ray afspilleren
        public void PlayDevice()
        {
        }

        // Stop afspilning på Blu-Ray afspilleren
        public void StopDevice()
        {
        }

        // Returnerer status for hele system, i form af en string.
        // Udskift "???" med navnet på det instance field, du har
        // defineret for hver af de fire devices i HT-systemet.
        public override string ToString()
        {
            string status = "Current status of Home Theater\n";
            status += "------------------------------\n";
            //status += $"Smart TV       : {ConvertOnOff(???.IsOn)}, showing channel {ConvertChannelNo(???.Channel)}\n";
            //status += $"Blu-Ray player : {ConvertOnOff(???.IsOn)}, is {ConvertBluRayStatus(???.IsPlaying)}\n";
            //status += $"Left Speaker   : {ConvertOnOff(???.IsOn)}, is at volume {???.CurrentVolume}\n";
            //status += $"Right Speaker  : {ConvertOnOff(???.IsOn)}, is at volume {???.CurrentVolume}\n";

            return status;
        }

        #region Private metoder
        private string ConvertOnOff(bool onOff)
        {
            return onOff ? "On" : "Off";
        }

        private string ConvertChannelNo(int channelNo)
        {
            return channelNo == 0 ? "(No channel)" : channelNo.ToString();
        }

        private string ConvertBluRayStatus(bool isPlaying)
        {
            return isPlaying ? "Playing" : "Stopped";
        } 
        #endregion
    }
}