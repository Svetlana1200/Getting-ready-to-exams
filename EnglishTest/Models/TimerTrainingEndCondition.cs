using System;

namespace EnglishTest.Models
{
    public class TimerTrainingEndCondition : ITrainingEndCondition
    {
        public DateTime StartTime;
        public bool WasStart = false;
        public int TotalTime;

        public TimerTrainingEndCondition(int time)
        {
            TotalTime = time;
        }

        public bool IsFinish(Results results)
        {
            var currentTime = DateTime.Now;
            if (!WasStart)
            {
                WasStart = true;
                StartTime = currentTime;
                return false;
            }
            return (currentTime - StartTime).TotalMinutes > TotalTime;
        }
    }
}
