using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EnglishTest.DownloadingToDB
{
    public class ParsingImageTask : IParsingTasks<FormatImageTask>
    {
        public string FirstPart = "https://englishapple.ru/index.php/exams/pet/reading-writing/three-option-multiple-choice/85-%D1%8D%D0%BA%D0%B7%D0%B0%D0%BC%D0%B5%D0%BD%D1%8B/pet/";
        public string SecondPart = "-pet-reading-part-1";
        public List<FormatImageTask> GetTasks()
        {
            var tasks = new List<FormatImageTask>();
            var start = 412;
            for (var i = 0; i < 5; i++)
            {
                if (i == 1)
                    start = 413;
                var uri = FirstPart + (start + i).ToString() + SecondPart + (i + 1).ToString();

                var html = HTML.GetHTML(uri);
                var partTasks = GetTasksFromOnePage(html);
                tasks.AddRange(partTasks);
                Console.WriteLine();
            }
            Console.WriteLine(tasks.Count);
            return tasks;
        }

        public List<FormatImageTask> GetTasksFromOnePage(string html)
        {
            var tasks = new List<FormatImageTask>();
            Regex regex = new Regex(@"self\.css\(""color"", color\);[\w\W]*?(<div[\w\W]*?){3}(<div[\w\W]*?)<p>&nbsp;</p>");
            MatchCollection matches = regex.Matches(html);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    var scripts = match.Groups[2].Value;
                    var q = 0;
                    Regex regex2 = new Regex(@"(<div class=""container-fluid"">\s*?(<div[\w\W]*?>\s*?){3})</div>[\w\W]*?<a class=""list-group-item disabled"">[\w\W]*?\d*?\)([\w\W]*?)</a>((<a class=""list-group-item[\w\W]*?</a>\s*?){3})");
                    MatchCollection matches2 = regex2.Matches(scripts);
                    if (matches2.Count > 0)
                    {
                        foreach (Match match2 in matches2)
                        {
                            q++;
                            Console.WriteLine(q);
                            var strWithoutDiv = match2.Groups[1].Value.Replace("</div>", "");
                            var countDiv = (strWithoutDiv.Length - strWithoutDiv.Replace("<div", "").Length) / "<div".Length;
                            var divs = new StringBuilder();
                            for (var i = 0; i < countDiv; i++)
                                divs.Append("</div>");
                            var pictureScript = strWithoutDiv + divs.ToString();

                            var questoin = match2.Groups[3].Value.Replace("</b>", "");

                            var answers = match2.Groups[4].Value;

                            var answer = "";
                            Regex regex3 = new Regex(@"correct[\w\W]*?([ABC])\)");
                            MatchCollection matches3 = regex3.Matches(answers);
                            if (matches3.Count > 0)
                            {
                                foreach (Match match3 in matches3)
                                {
                                    answer = match3.Groups[1].Value;
                                    //Console.WriteLine(answer);
                                }
                            }

                            var first = "";
                            var second = "";
                            var third = "";
                            regex3 = new Regex(@"A\)</b>([\w\W]*?)</a>[\w\W]*?B\)</b>([\w\W]*?)</a>[\w\W]*?C\)</b>([\w\W]*?)</a>");
                            matches3 = regex3.Matches(answers);
                            if (matches3.Count > 0)
                            {
                                foreach (Match match3 in matches3)
                                {
                                    first = match3.Groups[1].Value;
                                    second = match3.Groups[2].Value;
                                    third = match3.Groups[3].Value;
                                    //Console.WriteLine(first);
                                    //Console.WriteLine(second);
                                    //Console.WriteLine(third);
                                }
                            }
                            tasks.Add(new FormatImageTask(pictureScript, first, second, third, answer, questoin));
                            //Console.WriteLine(match2.Groups[4].Value);
                            //Console.WriteLine(questoin);
                            //Console.WriteLine(pictureScript);
                        }
                    }
                }
            }

            return tasks;
        }
    }
}
