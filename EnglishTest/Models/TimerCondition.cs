using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class TimerCondition : ITrainingEndCondition
    {
        public DateTime startTime;
        public bool wasStart = false;

        public bool isFinish(bool isRightAnswer, DateTime currentTime)
        {
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
