using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class OneMistakeTrainingEndCondition : ITrainingEndCondition
    {
        public bool isFinish(Results results)
        {
            foreach (var type in results.IncorrectTasks.Keys)
                if (results.IncorrectTasks[type] != 0)
                    return true;
            return false;
        }
    }
}
