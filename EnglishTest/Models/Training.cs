using System.Collections.Generic;

namespace EnglishTest.Models
{
    public class Training
    {
        public readonly IEnumerator<ITask> Tasks;

        public Training(IEnumerable<ITask> tasks)
        {
            Tasks = tasks.GetEnumerator();
        }
    }
}
