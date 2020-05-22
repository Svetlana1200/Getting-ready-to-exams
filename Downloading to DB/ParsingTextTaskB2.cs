using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EnglishTest.DownloadingToDB
{
    public class ParsingTextTaskB2 : IParsingTasks<FormatTextTask>
    {
        public static string FirstPart = "https://englishapple.ru/index.php/%D1%83%D1%87%D0%B8%D0%BC-%D0%B0%D0%BD%D0%B3%D0%BB%D0%B8%D0%B9%D1%81%D0%BA%D0%B8%D0%B9/%D0%B0%D1%83%D0%B4%D0%B8%D0%BE/";
        public static string SecondPart = "-cambridge-english-advanced-cae-use-of-english-open-cloze-test-";
        public static Regex regexText = new Regex(@"For questions 1-8,[\w\W]*?<h(4|3)[\w\W]*?<p>([\w\W]*?)</p>");
        public static Regex regexAnswer = new Regex(@"GAP (\d)+ \(([\w\s]*?)[\)/]");
    
        public List<FormatTextTask> GetTasks()
        {
            var tasks = new List<FormatTextTask>();
            var start = 665;
            for (var i = 0; i < 20; i++)
            {
                Console.WriteLine("НОмер" + (i + 1).ToString());
                if (i == 4)
                    start = 668;
                FormatTextTask partTasks = null;
                var uri = FirstPart + (start + i).ToString() + SecondPart + (i + 1).ToString();
                var html = HTML.GetHTML(uri);
                partTasks = GetTasksFromOnePage(html);
                Console.WriteLine();
                if (partTasks.Text.Length > 100)
                    tasks.Add(partTasks);
            }
            Console.WriteLine(tasks.Count);
            return tasks;
        }

        private FormatTextTask GetTasksFromOnePage(string html)
        {
            MatchCollection matches = regexText.Matches(html);
            var text = "";
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    text = match.Groups[2].Value.Replace("…", "_");
                    text = text.Replace("<br />", "\n").Replace("...", "_");
                    Console.WriteLine(text);
                }
            }
            Regex regexAnswers = new Regex(@"\[answer=""([\w\W]*?)[""#]");
            matches = regexAnswers.Matches(html);
            var answers = new List<string>();
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    answers.Add(match.Groups[1].Value.ToLower());
                }
            }
            return new FormatTextTask(text, answers);
        }
    }
}
