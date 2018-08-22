using System.Collections.Generic;

namespace SlotMachineDemo.Configuration
{
    /// <summary>
    /// This class contains constants from the Slot Machine domain
    /// </summary>
    public class Constants
    {
        public const int NoOfWheels = 3;

        public static readonly List<int> TickScaleWinnings125Repeat = new List<int>
        {
            0,
            1,
            2,
            5,
            10,
            20,
            50,
            100,
            200,
            500,
            1000,
            2000,
            5000,
            10000,
            20000,
            50000,
            100000
        };

        public static readonly List<int> TickScaleAutoPlay10Power = new List<int>
        {
            100,
            1000,
            10000,
            100000,
            1000000,
            10000000,
            100000000,
            1000000000
        };
    }
}
