using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class ImageTraining : Training
    {
        public ImageTraining(TaskService db, string level, ITrainingEndCondition condition) : base(db, level, condition) {}

        public override void CreateTasks()
        {
            AddTasks("images", ImageAnswer.MaxCount);
            TasksIds = new List<string>(Tasks.Keys);
            Results = new Results(Tasks, MaxCount);
            isFinish = Condition.isFinish(Results);
        }
    }
}
