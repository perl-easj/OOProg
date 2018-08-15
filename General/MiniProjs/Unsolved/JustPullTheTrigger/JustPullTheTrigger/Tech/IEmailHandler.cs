namespace JustPullTheTrigger.Tech
{
    public interface IEmailHandler
    {
        void Send(Email mail);
        Email Receive(string receiver);
    }
}