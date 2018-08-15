namespace JustPullTheTrigger.Participants
{
    public interface IParticipant
    {
        string Description { get; }
        void Report(string info);
    }
}