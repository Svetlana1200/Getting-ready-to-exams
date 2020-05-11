namespace EnglishTest.Models
{
    public class SentenceAnswer : IAnswer
    {
        public const int MaxCount = 2;
        public readonly string First;
        public readonly string[] Second;
        public readonly string Word;
        public readonly string RightAnswer;
        public readonly string UserAnswer;
        public int Count { get; private set; }

        public SentenceAnswer(string first, string second, string word, string rightAnswer, string userAnswer)
        {
            First = first;
            Second = second.Split('_');
            Word = word;
            RightAnswer = rightAnswer;
            UserAnswer = userAnswer;
        }

        public bool IsRight()
        {
            Count = 0;
            if (RightAnswer == UserAnswer)
            {
                Count = MaxCount;
                return true;
            }
            return false;
        }
    }
}
