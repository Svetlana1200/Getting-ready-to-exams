using System.Collections.Generic;

namespace EnglishTest.Models
{
    public class ImageTraining : Training
    {
        public ImageTraining(Parameters.Levels level, ITrainingEndCondition condition) 
            : base(level, condition) {}

        public override void CreateTasks(TaskService db, int tasksNumber)
        {
            AddTasks(db, "images", ImageAnswer.MaxCount, tasksNumber);
            TasksIds = new List<string>(Tasks.Keys);
            Results = new Results(Tasks, MaxCount);
            isFinish = Condition.IsFinish(Results);
        }
    }
}
