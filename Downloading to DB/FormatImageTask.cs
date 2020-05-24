using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishTest.DownloadingToDB
{
    public class FormatImageTask
    {
        public string ScriptHTML;
        public string First;
        public string Second;
        public string Third;
        public string Answer;
        public string Question;

        private Dictionary<string, string> nameAnswers = new Dictionary<string, string>
        {
            { "A", "1" },
            { "B", "2" },
            { "C", "3" }
        };

        public FormatImageTask(string scriptHTML, string first, string second, string third, string answer, string question)
        {
            ScriptHTML = scriptHTML;
            First = first;
            Second = second;
            Third = third;
            Question = question;
            Answer = nameAnswers[answer];
        }
    }
}
