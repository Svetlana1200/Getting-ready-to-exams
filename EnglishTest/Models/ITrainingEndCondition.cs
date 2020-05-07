using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public interface ITrainingEndCondition
    {
        bool isFinish(bool isRightAnswer, DateTime currentTime);
    }
}
