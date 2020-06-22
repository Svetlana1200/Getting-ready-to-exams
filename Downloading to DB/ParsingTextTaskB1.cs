using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EnglishTest.DownloadingToDB
{
    public class ParsingTextTaskB1 : IParsingTasks<FormatTextTask>
    {
        private readonly static string FirstPart = "https://englishapple.ru/index.php/%D1%83%D1%87%D0%B8%D0%BC-%D0%B0%D0%BD%D0%B3%D0%BB%D0%B8%D0%B9%D1%81%D0%BA%D0%B8%D0%B9/%D0%B0%D1%83%D0%B4%D0%B8%D0%BE/";
        private readonly static string SecondPart = "-fce-use-of-english-open-cloze-test-";
        private readonly static Regex regexText = new Regex(@"<(h3|h4) style[\w\W]*?</(h3|h4)>[\w\W]*?(<(p|h4)[\w\W]*?>([\w\d\s,:""!.?]*?<[\w\W]*?</b><span>&nbsp;</span>\.\.\.)*?</(p|h4)>\s*<(p|h4)[\w\W]*?>([\w\d\s,:""!.?]*?<[\w\W]*?</b><span>&nbsp;</span>\.\.\.)*?[\w\d\s,:""!.?]*?</(p|h4)>)");
        private readonly static Regex regexAnswer = new Regex(@"GAP (\d)+ \(([\w\s]*?)[\)/]");
        public List<FormatTextTask> GetTasks()
        {
            var tasks = new List<FormatTextTask>();

            for (var i = 0; i < 13; i++)
            {
                var uri = FirstPart + (626 + i).ToString() + SecondPart + (8 + i).ToString();
                var html = HTML.GetHTML(uri);
                var partTasks = GetTasksFromOnePage(html);
                tasks.Add(partTasks);
            }
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
                    text = match.Groups[3].Value;
                    text = text.Replace("</i><span>&nbsp;</span>", " ");
                    text = Regex.Replace(text, @"<i style=[\w\W]*?>", "");
                    text = Regex.Replace(text, @"<(p|h4) style=[\w\W]*?>", "");
                    text = text.Replace("<span>&nbsp;</span></p>", "");
                    text = text.Replace("</p>", "");
                    text = text.Replace("<span>&nbsp;</span></h4>", "");
                    text = text.Replace("</h4>", "");
                    text = Regex.Replace(text, @"<span>&nbsp;</span><b[\w\W]*?\.\.\.", "_");
                    text = Regex.Replace(text, @"<(p|h4)>[\w\W]*", "");
                    text = text.Replace("<span>&nbsp;</span>", " ");
                }
            }

            var partsText = text.Trim('\n', ' ').Split("_");
            var textWithNumbers = new StringBuilder(partsText[0]);
            for (var i = 1; i < partsText.Length; i++)
            {
                textWithNumbers.Append(" " + i.ToString() + "._" + partsText[i]);
            }

            var answers = new List<string>();
            matches = regexAnswer.Matches(html);
            if (matches.Count > 0)
            {
                foreach(Match match in matches)
                {
                    answers.Add(match.Groups[2].Value.ToLower());
                }
            }
            return new FormatTextTask(textWithNumbers.ToString(), answers);
        }
    }
}
