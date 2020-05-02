namespace EnglishTest.Models
{
    public class SentenceAnswer : IAnswer
    {
        public readonly string First;
        public readonly string[] Second;
        public readonly string Word;
        public readonly string Answer;
        public readonly string UserAnswer;
        public readonly int MaxCount;
        public int Count { get; private set; }

        public SentenceAnswer(string first, string second, string word, string answer, int maxCount, string userAnswer)
        {
            First = first;
            Second = second.Split('_');
            Word = word;
            Answer = answer;
            UserAnswer = userAnswer;
            MaxCount = maxCount;
            Count = 0;
        }

        public bool IsRight()
        {
            if (Answer == UserAnswer)
            {
                Count = MaxCount;
                return true;
            }
            return false;
        }
    }
}
