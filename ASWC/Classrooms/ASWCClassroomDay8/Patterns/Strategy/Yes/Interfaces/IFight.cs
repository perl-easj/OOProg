namespace Patterns.Strategy.Yes.Interfaces
{
    public interface IFight
    {
        void Fight(IPlayer self, IPlayer opponent);
    }
}