namespace EnglishTest.DownloadingToDB
{
    public class FormatSentencesTask
    {
        public readonly string First;
        public readonly string Word;
        public readonly string Beginning;
        public readonly string Answer;
        public readonly string Ending;

        public FormatSentencesTask(string first, string word, string beginning,
                                   string answer, string ending)
        {
            First = first;
            Word = word;
            Beginning = beginning;
            Answer = answer;
            Ending = ending;
        }
    }
}
