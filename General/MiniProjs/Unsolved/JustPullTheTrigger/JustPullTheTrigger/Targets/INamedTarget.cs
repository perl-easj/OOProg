namespace JustPullTheTrigger.Targets
{
    public interface INamedTarget : ITarget
    {
        string Name { get; }
    }
}