using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class OneMistakeCondition : ITrainingEndCondition
    {
        public bool isFinish(bool isRightAnswer, DateTime currentTime)
        {
            return !isRightAnswer;
        }
    }
}
