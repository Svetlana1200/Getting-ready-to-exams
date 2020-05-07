using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class EndTasksTrainingEndCondition : ITrainingEndCondition
    {
        public bool isFinish(Results results)
        {
            return false;
        }
    }
}
