namespace EnglishTest.Models
{
    public class TextAnswer : IAnswer
    {
        public readonly string[] Text;
        public readonly string[] Answer;
        public readonly string[] UserAnswer;

        public TextAnswer(string text, string[] answer, string userAnswer)
        {
            Text = text.Split('_');
            Answer = answer;
            UserAnswer = userAnswer.Split(',');
        }

        public bool IsRight()
        {
            for (var i = 0; i < UserAnswer.Length; i++)
            {
                if (UserAnswer[i] != Answer[i])
                    return false;
            }
            return true;
        }
    }
}
