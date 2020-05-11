namespace EnglishTest.Models
{
    public class TextAnswer : IAnswer
    {
        public const int MaxCount = 8;
        public readonly string[] Text;
        public readonly string[] RightAnswer;
        public readonly string[] UserAnswer;
        public int Count { get; private set; }

        public TextAnswer(string text, string[] rightAnswer, string userAnswer)
        {
            Text = text.Split('_');
            RightAnswer = rightAnswer;
            UserAnswer = userAnswer.Split(',');
        }

        public bool IsRight()
        {
            Count = 0;
            for (var i = 0; i < UserAnswer.Length; i++)
            {
                if (UserAnswer[i] == RightAnswer[i])
                    Count++;
            }
            return Count == MaxCount;
        }
    }
}
