using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraDuracaoCSharp.Controller
{
    public class ControllerCalcs
    {
        public static void Sum(TimeSpan startTime, TimeSpan endTime, out TimeSpan duration)
        {
            ModelCalcs calc = new(startTime, endTime);
            calc.Sum();
            duration = calc.Duration;
        }

        public static void Subtract(TimeSpan startTime, TimeSpan endTime, out TimeSpan duration)
        {
            ModelCalcs calc = new(startTime, endTime);
            calc.Subtract();
            duration = calc.Duration;
        }
    }
}