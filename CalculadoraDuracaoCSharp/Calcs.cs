using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraDuracaoCSharp
{
    public class Calcs
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan Duration { get; private set; }

        public Calcs(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public void Sum()
        {
            Duration = EndTime.Add(StartTime);
        }

        public void Subtract()
        {
            // Ensure StartTime is less than EndTime to avoid negative durations
            if (EndTime < StartTime)
            {
                TimeSpan temp = EndTime;
                EndTime = StartTime;
                StartTime = temp;
            }
            Duration = EndTime.Subtract(StartTime);
        }

    }
}
