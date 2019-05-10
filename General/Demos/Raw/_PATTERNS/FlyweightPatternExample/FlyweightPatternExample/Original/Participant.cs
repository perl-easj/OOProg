using FlyweightPatternExample.Common;

namespace FlyweightPatternExample.Original
{
    public class Participant
    {
        public string Name { get; }
        public ParticipantType PartType { get; }
        public int[] AnimationBinaryData { get; private set; }
        public double X { get; set; }
        public double Y { get; set; }
        public ParticipantMode Mode { get; set; }

        public Participant(string name, ParticipantType partType)
        {
            Name = name;
            PartType = partType;
            AnimationBinaryData = AnimationInfoDatabase.GetAnimationBinaryData(PartType);
            Mode = ParticipantMode.idle;
            X = 0;
            Y = 0;
        }

        public void Animate()
        {
            AnimationManager.PerformAnimation(X, Y, Mode, AnimationBinaryData);
        }
    }
}