namespace EnglishTest.Models
{
    public class TextAnswer : IAnswer
    {
        public readonly string[] Text;
        public readonly string[] Answer;
        public readonly string[] UserAnswer;
        public readonly int MaxCount;
        public int Count { get; private set; }

        public TextAnswer(string text, string[] answer, int maxCount, string userAnswer)
        {
            Text = text.Split('_');
            Answer = answer;
            UserAnswer = userAnswer.Split(',');
            MaxCount = maxCount;
        }

        public bool IsRight()
        {
            Count = 0;
            for (var i = 0; i < UserAnswer.Length; i++)
            {
                if (UserAnswer[i] == Answer[i])
                    Count++;
            }
            return Count == MaxCount;
        }
    }
}
