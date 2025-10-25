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

        public ModelCalcs()
        {
        }

        public ModelCalcs(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public TimeSpan Sum()
        {
            return EndTime + StartTime;
        }

        public TimeSpan Subtract()
        {
            if (EndTime < StartTime)
            {
                TimeSpan temp = EndTime;
                EndTime = StartTime;
                StartTime = temp;
            }
            return EndTime - StartTime;
        }
    }
}
