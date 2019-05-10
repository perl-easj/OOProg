namespace ObservableInt
{
    public class ObserverWithState
    {
        public string InitialState
        {
            get { return "Not called yet"; }
        }

        public string State
        {
            get;
            protected set;
        }

        public ObserverWithState()
        {
            State = InitialState;
        }
    }
}