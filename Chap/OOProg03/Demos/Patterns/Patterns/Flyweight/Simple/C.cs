// ReSharper disable UnassignedGetOnlyAutoProperty
namespace Patterns.Flyweight.Simple
{
    public class C
    {
        public InState TheInState { get; }
        public ExState TheExState { get; }

        public C(InState inState, ExState exState)
        {
            TheInState = inState;
            TheExState = exState;
        }

        public void Op()
        {
            TheInState.Op(TheExState);
        }
    }
}