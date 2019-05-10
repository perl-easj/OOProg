using System;

namespace ObservableInt
{
    public class ObserverA : ObserverWithState
    {
        public void MethodA(int val)
        {
            State = $"Value was updated to {val}";
            Console.WriteLine(State);
        }
    }
}