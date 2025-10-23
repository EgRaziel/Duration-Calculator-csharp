using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CalculadoraDuracaoCSharp
{
    public class ModelCalcs
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan Duration { get; private set; }

        public ModelCalcs(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public void Sum()
        {
            Duration = EndTime + StartTime;
        }

        public void Subtract()
        {
            if (EndTime < StartTime)
            {
                TimeSpan temp = EndTime;
                EndTime = StartTime;
                StartTime = temp;
            }
            Duration = EndTime - StartTime;
        }
    }
}
