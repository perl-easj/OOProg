using System.Collections.Generic;
using Windows.UI;
using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.Helpers;

namespace SimpleRPGFromScratch
{
    public partial class JewelCutQuality : DomainClassBase<JewelCutQuality>
    {
        public static List<double> LegalCutQualityValues = new List<double>
          { 0.3, 0.4, 0.5, 0.6, 0.8,
            1.0, 1.1, 1.2, 1.3, 1.5, 1.8,
            2.0, 2.2, 2.5, 2.8, 3.0 };

        private static IColorMapper<double> _cutQualityColorMapper;

        public static IColorMapper<double> CutQualityColorMapper
        {
            get
            {
                return _cutQualityColorMapper ?? (_cutQualityColorMapper = new ColorMapperIntervals<double>(
                           new List<double> { 0.5, 0.7, 0.9, 1.1, 1.3, 1.7 },
                           new List<Color>
                           {
                               Colors.Gray,
                               Colors.LightSlateGray,
                               Colors.DeepSkyBlue,
                               Colors.ForestGreen,
                               Colors.SandyBrown,
                               Colors.Silver,
                               Colors.Gold,
                           },
                           (a,b) => a < b));
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

        public override void CopyValuesFromObj(JewelCutQuality obj)
        {
            Description = obj.Description;
            Factor = obj.Factor;
        }

        public override void SetInitialValues()
        {
            Factor = 1.0;
        }
    }
}