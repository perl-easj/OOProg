using System.Collections.Generic;

namespace Patterns.Flyweight.Simple
{
    public class CFactory
    {
        private Dictionary<Context, InState> _inStates;

        public CFactory()
        {
            _inStates = new Dictionary<Context, InState>();
        }

        public C Create(Context data)
        {
            ExState exState = ContextToExState(data);
            InState inState = ContextToInState(data);
            return new C(inState, exState);
        }

        private ExState ContextToExState(Context data)
        {
            // "Calculate" new ExState data from context
            return new ExState();
        }

        private InState ContextToInState(Context data)
        {
            // Only calculate new InState data if needed.
            if (!_inStates.ContainsKey(data))
            {
                _inStates[data] = new InState();
            }

            return _inStates[data];
        }
    }
}