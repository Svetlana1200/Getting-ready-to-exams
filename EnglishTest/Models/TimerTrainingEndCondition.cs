using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class TimerTrainingEndCondition : ITrainingEndCondition
    {
        public DateTime startTime;
        public bool wasStart = false;

        public bool isFinish(Results results)
        {
            var currentTime = DateTime.Now;
            if (!wasStart)
            {
                wasStart = true;
                startTime = currentTime;
                return false;
            }
            return (currentTime - startTime).TotalSeconds > 10;
        }
    }
}
