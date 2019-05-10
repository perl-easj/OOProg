using System;
using System.Threading.Tasks;

namespace MultiProg01
{
    public class PiCalc
    {
        public async Task<double> CalculateAsync(CalcResult cr)
        {
            Random _generator = new Random();
            int inside = 0;
            double piCurrent = 0.0;

            await Task.Run(() =>
            {
                for (long i = 1; i <= 1000000000000 && !cr.Quit; i++)
                {
                    double x = _generator.NextDouble();
                    double y = _generator.NextDouble();

                    if (x * x + y * y < 1.0)
                    {
                        inside++;
                    }

                    piCurrent = inside * 4.0 / i;
                    cr.Pi = piCurrent;
                    cr.Iterations = i;
                }
            });

            return piCurrent;
        }
    }
}