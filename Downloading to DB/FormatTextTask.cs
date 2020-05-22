using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishTest.DownloadingToDB
{
    public class FormatTextTask
    {
        public readonly string Text;
        public readonly List<string> Answers;
        public FormatTextTask(string text, List<string> answers)
        {
            Text = text;
            Answers = answers;
        }
    }
}
