using FlyweightPatternExample.Common;

namespace FlyweightPatternExample.Improved
{
    public class ParticipantWrapper
    {
        private ParticipantImproved _pi;
        private ParticipantExtrinsicState _pex;

        public ParticipantWrapper(ParticipantImproved pi, ParticipantExtrinsicState pex)
        {
            _pi = pi;
            _pex = pex;
        }

        public void Animate()
        {
            AnimationManager.PerformAnimation(_pex.X, _pex.Y, _pex.Mode, _pi.IntrinsicState.AnimationBinaryData);
        }
    }
}