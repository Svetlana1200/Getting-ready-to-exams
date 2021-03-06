﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EnglishTest.DownloadingToDB
{
    class ParsingSentencesTaskB1 : IParsingTasks<FormatSentencesTask>
    {
        private readonly static string firstPart = "https://englishapple.ru/index.php/%D1%83%D1%87%D0%B8%D0%BC-%D0%B0%D0%BD%D0%B3%D0%BB%D0%B8%D0%B9%D1%81%D0%BA%D0%B8%D0%B9/%D0%B0%D1%83%D0%B4%D0%B8%D0%BE/84-%D1%8D%D0%BA%D0%B7%D0%B0%D0%BC%D0%B5%D0%BD%D1%8B/fce/";
        private readonly static string secondPart = "-key-word-transformations-";
        private readonly static Regex regex = new Regex(@"first="" ([\w\W]*?\.)[\w\W]*?word=""(\w*?)"" beginning=""([\w\W]*?)""&nbsp;answer=""([\w\W]*?)(#[\w\W]*?)?"" ending=""([\w\W]*?.)""");


        public List<FormatSentencesTask> GetTasks()
        {
            var tasks = new List<FormatSentencesTask>();
            var start = 582;
            for (var i = 0; i < 10; i++)
            {
                if (i == 4)
                    start = 588;
                var uri = firstPart + (start - i).ToString() + secondPart + (i + 7).ToString();
                var html = HTML.GetHTML(uri);
                var partTasks = GetTasksFromOnePage(html);
                tasks.AddRange(partTasks);
            }
            return tasks;
        }

        private List<FormatSentencesTask> GetTasksFromOnePage(string html)
        {
            var tasks = new List<FormatSentencesTask>();
            MatchCollection matches = regex.Matches(html);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    if (match.Groups[1].Value.Length < 120 &&
                        match.Groups[1].Value.Length > 0 &&
                        match.Groups[2].Value.Length < 25 &&
                        match.Groups[2].Value.Length > 0 &&
                        match.Groups[3].Value.Length < 120 &&
                        match.Groups[3].Value.Length > 0 &&
                        match.Groups[4].Value.Length < 120 &&
                        match.Groups[4].Value.Length > 0 &&
                        match.Groups[6].Value.Length < 120 &&
                        match.Groups[6].Value.Length > 0)
                    {
                        tasks.Add(new FormatSentencesTask(
                            match.Groups[1].Value,
                            match.Groups[2].Value,
                            match.Groups[3].Value,
                            match.Groups[4].Value,
                            match.Groups[6].Value));
                    }
                }
            }
            return tasks;
        }
    }
}
