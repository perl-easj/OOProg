using FlyweightPatternExample.Common;

namespace FlyweightPatternExample.Improved
{
    public class ParticipantExtrinsicState
    {
        public string Name { get; }
        public ParticipantType PartType { get; }
        public double X { get; set; }
        public double Y { get; set; }
        public ParticipantMode Mode { get; set; }

        public ParticipantExtrinsicState(string name, ParticipantType partType)
        {
            Name = name;
            PartType = partType;
            Mode = ParticipantMode.idle;
            X = 0;
            Y = 0;
        }
    }
}