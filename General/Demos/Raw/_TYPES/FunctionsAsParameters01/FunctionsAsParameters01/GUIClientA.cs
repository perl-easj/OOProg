using System;

namespace FunctionsAsParameters01
{
    public class GUIClient
    {
        // Rest of class omitted by brevity
        public void TemperatureHasChanged(double temperature)
        {
            Console.WriteLine("Current temperature : " + temperature);
        }
    }
}