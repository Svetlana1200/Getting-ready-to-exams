namespace EnglishTest.Models
{
    public class TextAnswer : IAnswer
    {
        public const int MaxCount = 8;
        public readonly string[] Text;
        public readonly string[] RightAnswer;
        public readonly string[] UserAnswer;
        public bool[] AnswersRightness;
        public int Count { get; private set; }

        public TextAnswer(string text, string[] rightAnswer, string userAnswer)
        {
            Text = text.Split('_');
            RightAnswer = rightAnswer;
            UserAnswer = userAnswer.Split(',');
            AnswersRightness = new bool[RightAnswer.Length];
        }

        public bool IsRight()
        {
            Count = 0;
            for (var i = 0; i < UserAnswer.Length; i++)
            {
                if (string.Compare(UserAnswer[i], RightAnswer[i], true) == 0)
                {
                    Count++;
                    AnswersRightness[i] = true;
                }
            }
            return Count == MaxCount;
        }
    }
}
