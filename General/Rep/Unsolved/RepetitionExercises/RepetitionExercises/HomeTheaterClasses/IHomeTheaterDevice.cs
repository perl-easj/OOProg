namespace RepetitionExercises
{
    // Minimalt interface for "devices", 
    // som kan indgå i et HT-system.
    public interface IHomeTheaterDevice
    { 
        bool IsOn { get; }
        void ToggleOnOff();
    }
}