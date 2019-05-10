using System;

namespace FunctionsAsParameters01
{
    public class TemperatureMonitor
    {
        private double _temperature;

        public Action<double> TemperatureChanged;

        public TemperatureMonitor()
        {
            TemperatureChanged = null;
            MonitorDevice();
            _temperature = GetTemperatureFromDevice();
        }


        private void MonitorDevice()
        {
            // We assume GetTemperatureFromDevice retrieves
            // an actual temperature from some device
            double newTemperature = GetTemperatureFromDevice();

            if (Math.Abs(newTemperature - _temperature) > 0.1)
            {
                _temperature = newTemperature;
                OnTemperatureChanged();
            }


        }

        private void OnTemperatureChanged()
        {
            TemperatureChanged?.Invoke(_temperature);
        }

        private double GetTemperatureFromDevice()
        {
            return 0.0;
        }
    }
}