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
        public readonly string Class;
        public int Count { get; private set; }

        public SentenceAnswer(string first, string second, string word, string rightAnswer, string userAnswer)
        {
            First = first;
            Second = second.Split('_');
            Word = word;
            RightAnswer = rightAnswer;
            UserAnswer = userAnswer;
            if (string.Compare(RightAnswer, UserAnswer, true) != 0)
                Class = "wrong";
        }

        public bool IsRight()
        {
            Count = 0;
            if (string.Compare(RightAnswer, UserAnswer, true) == 0)
            {
                Count = MaxCount;
                return true;
            }
            return false;
        }
    }
}
