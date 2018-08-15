using WesternStrike.Combat;

namespace WesternStrike.Guns
{
    public class RugerRevolver
    {
        public double Damage
        {
            get { return 25 + NumberGenerator.Next(0, 15); }
        }
    }
}