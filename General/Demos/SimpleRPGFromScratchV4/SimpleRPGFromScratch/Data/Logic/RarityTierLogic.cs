using System.Collections.Generic;
using Windows.UI;
using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.Helpers;

namespace SimpleRPGFromScratch
{
    public partial class RarityTier : DomainClassBase<RarityTier>
    {
        private static IColorMapper<int> _rarityColorMapper;

        public static IColorMapper<int> RarityColorMapper
        {
            get
            {
                return _rarityColorMapper ?? (_rarityColorMapper = new ColorMapperValues<int>(
                           new List<int> {1, 2, 3, 4},
                           new List<Color> {Colors.LightGray, Colors.LightGreen, Colors.LightBlue, Colors.LightSalmon}));
            }
        }

        public override int GetId()
        {
            return Id;
        }

        public override void SetId(int id)
        {
            Id = id;
        }

        public override void CopyValuesFromObj(RarityTier obj)
        {
            Description = obj.Description;
        }
    }
}