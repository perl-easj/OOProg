using System;

namespace ObservableInt
{
    public class ObserverB : ObserverWithState
    {
        public void MethodB(int val)
        {
            State = $"Value is now {val}";
            Console.WriteLine(State);
        }
    }
}