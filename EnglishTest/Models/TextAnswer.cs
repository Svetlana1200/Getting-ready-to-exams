namespace EnglishTest.Models
{
    public class TextAnswer : IAnswer
    {
        public const int MaxCount = 8;
        public readonly string[] Text;
        public readonly string[] RightAnswer;
        public readonly string[] UserAnswer;
        public readonly string[] Classes;
        public int Count { get; private set; }

        public TextAnswer(string text, string[] rightAnswer, string userAnswer)
        {
            Text = text.Split('_');
            RightAnswer = rightAnswer;
            UserAnswer = userAnswer.Split(',');
            Classes = new string[UserAnswer.Length];
            for (var i = 0; i < UserAnswer.Length; i++)
            {
                if (UserAnswer[i].ToLower() != RightAnswer[i].ToLower())
                    Classes[i] = "wrong";
                else
                    Classes[i] = "right";
            }
        }

        public bool IsRight()
        {
            Count = 0;
            for (var i = 0; i < UserAnswer.Length; i++)
            {
                if (UserAnswer[i].ToLower() == RightAnswer[i].ToLower())
                    Count++;
            }
            return Count == MaxCount;
        }
    }
}
