using Patterns.Strategy.No.Interfaces;

namespace Patterns.Strategy.No.Strategies
{
    public class SunFightDefensive : IFight
    {
        public void Fight(IPlayer self, IPlayer opponent)
        {
            // Fight using Sun abilities,
            // in a defensive manner.
        }
    }

    public class SunFightOffensive : IFight
    {
        public void Fight(IPlayer self, IPlayer opponent)
        {
            // Fight using Sun abilities,
            // in a offensive manner.
        }
    }

    public class MoonFightDefensive : IFight
    {
        public void Fight(IPlayer self, IPlayer opponent)
        {
            // Fight using Moon abilities,
            // in a defensive manner.
        }
    }

    public class MoonFightOffensive : IFight
    {
        public void Fight(IPlayer self, IPlayer opponent)
        {
            // Fight using Moon abilities,
            // in a offensive manner.
        }
    }

    public class StarsFightDefensive : IFight
    {
        public void Fight(IPlayer self, IPlayer opponent)
        {
            // Fight using Stars abilities,
            // in a defensive manner.
        }
    }

    public class StarsFightOffensive : IFight
    {
        public void Fight(IPlayer self, IPlayer opponent)
        {
            // Fight using Stars abilities,
            // in a offensive manner.
        }
    }
}