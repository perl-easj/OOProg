using System;

namespace ClockV10
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            Clock myClock = new Clock(13,58);
            Console.WriteLine(myClock.Display);

            myClock.AdvanceOneMinute();
            Console.WriteLine(myClock.Display);

            myClock.AdvanceOneMinute();
            Console.WriteLine(myClock.Display);

            myClock.AdvanceOneMinute();
            Console.WriteLine(myClock.Display);

            myClock.SetTime(23,58);
            Console.WriteLine(myClock.Display);

            myClock.AdvanceOneMinute();
            Console.WriteLine(myClock.Display);

            myClock.AdvanceOneMinute();
            Console.WriteLine(myClock.Display);

            myClock.AdvanceOneMinute();
            Console.WriteLine(myClock.Display);

            // The LAST line of code should be ABOVE this line
        }
    }
}