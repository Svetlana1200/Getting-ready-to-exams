using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EnglishTest.DownloadingToDB
{
    public class ParsingImageTask : IParsingTasks<FormatImageTask>
    {
        private readonly static string firstPart = "https://englishapple.ru/index.php/exams/pet/reading-writing/three-option-multiple-choice/85-%D1%8D%D0%BA%D0%B7%D0%B0%D0%BC%D0%B5%D0%BD%D1%8B/pet/";
        private readonly static string secondPart = "-pet-reading-part-1";
        private readonly static Regex regexScripts = new Regex(@"self\.css\(""color"", color\);[\w\W]*?(<div[\w\W]*?){3}(<div[\w\W]*?)<p>&nbsp;</p>");
        private readonly static Regex regexInfo = new Regex(@"(<div class=""container-fluid"">\s*?(<div[\w\W]*?>\s*?){3})</div>[\w\W]*?<a class=""list-group-item disabled"">[\w\W]*?\d*?\)([\w\W]*?)</a>((<a class=""list-group-item[\w\W]*?</a>\s*?){3})");
        private readonly static Regex regexAswer = new Regex(@"correct[\w\W]*?([ABC])\)");
        private readonly static Regex regexVariants = new Regex(@"A\)</b>([\w\W]*?)</a>[\w\W]*?B\)</b>([\w\W]*?)</a>[\w\W]*?C\)</b>([\w\W]*?)</a>");
        public List<FormatImageTask> GetTasks()
        {
            var tasks = new List<FormatImageTask>();
            var start = 412;
            for (var i = 0; i < 5; i++)
            {
                if (i == 1)
                    start = 413;
                var uri = firstPart + (start + i).ToString() + secondPart + (i + 1).ToString();

                var html = HTML.GetHTML(uri);
                var partTasks = GetTasksFromOnePage(html);
                tasks.AddRange(partTasks);
            }
            return tasks;
        }

        private List<FormatImageTask> GetTasksFromOnePage(string html)
        {
            var tasks = new List<FormatImageTask>();
            MatchCollection matches = regexScripts.Matches(html);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    var scripts = match.Groups[2].Value;
                    MatchCollection matches2 = regexInfo.Matches(scripts);
                    if (matches2.Count > 0)
                    {
                        foreach (Match match2 in matches2)
                        {
                            var strWithoutDiv = match2.Groups[1].Value.Replace("</div>", "");
                            var countDiv = (strWithoutDiv.Length - strWithoutDiv.Replace("<div", "").Length) / "<div".Length;
                            var divs = new StringBuilder();
                            for (var i = 0; i < countDiv; i++)
                                divs.Append("</div>");
                            var pictureScript = strWithoutDiv + divs.ToString();

                            var questoin = match2.Groups[3].Value.Replace("</b>", "");

                            var answers = match2.Groups[4].Value;

                            var answer = "";
                            MatchCollection matches3 = regexAswer.Matches(answers);
                            if (matches3.Count > 0)
                            {
                                foreach (Match match3 in matches3)
                                {
                                    answer = match3.Groups[1].Value;
                                }
                            }

                            var first = "";
                            var second = "";
                            var third = "";
                            matches3 = regexVariants.Matches(answers);
                            if (matches3.Count > 0)
                            {
                                foreach (Match match3 in matches3)
                                {
                                    first = match3.Groups[1].Value;
                                    second = match3.Groups[2].Value;
                                    third = match3.Groups[3].Value;
                                }
                            }
                            tasks.Add(new FormatImageTask(pictureScript, first, second, third, answer, questoin));
                        }
                    }
                }
            }

            return tasks;
        }
    }
}
