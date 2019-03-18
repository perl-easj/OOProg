using System;

namespace NaiveRPG.Factories
{
    public class ItemFactoryLibraryEN: IItemFactoryLibrary
    {
        private static Random _rng = new Random(Guid.NewGuid().GetHashCode());

        public string GenerateDescription()
        {
            return null;
        }

        private string GenerateColorDesc()
        {
            double rnd = _rng.Next(100);

            if (rnd < 50)
            {
                return "Brown";
            }
            else
            {

            }
        }

        private string GenerateQualityDesc()
        {
            return "Shiny New";
        }
    }
}