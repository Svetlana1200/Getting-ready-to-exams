using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class ImageTraining : ITraining
    {
        public ImageTraining(TaskService db, string level, ICondition condition) : base(db, level, condition) {}

        async public override Task CreateTasks()
        {
            await AddTasks("images", ImageAnswer.MaxCount);
            TasksId = new List<string>(Tasks.Keys);
            Results = new Results(Tasks, MaxCount);
        }
    }
}
