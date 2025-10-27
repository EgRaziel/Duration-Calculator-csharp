using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculadoraDuracaoCSharp.Model;

namespace CalculadoraDuracaoCSharp.Controller
{
    public class ControllerCalcs
    {
        public static TimeSpan Sum(TimeSpan startTime, TimeSpan endTime)
        {
            ModelCalcs modelCalcs = new(startTime, endTime);
            return modelCalcs.Sum();
        }

        public static TimeSpan Subtract(TimeSpan startTime, TimeSpan endTime)
        {
            ModelCalcs modelCalcs = new(startTime, endTime);
            return modelCalcs.Subtract();
        }
    }
}