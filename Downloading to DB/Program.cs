using System;

namespace EnglishTest.DownloadingToDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new ParsingSentencesTask<FormatSentencesTask>().GetTasks();
            
        }
    }
}
