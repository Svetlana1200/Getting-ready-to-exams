using System.Collections.Generic;

namespace EnglishTest.DownloadingToDB
{
    public interface IParsingTasks<T>
    {
        List<T> GetTasks();
        List<T> GetTasksFromOnePage(string html);
        string GetHTML(string url);
    }
}
