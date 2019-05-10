namespace AdvLINQ
{
    public abstract class FlyweightBase<Tex, Tin>
    {
        public Tex ExtrinsicState { get; }
        public Tin IntrinsicState { get; }

        protected FlyweightBase(Tex extrinsicState, Tin intrinsicState)
        {
            ExtrinsicState = extrinsicState;
            IntrinsicState = intrinsicState;
        }
    }
}