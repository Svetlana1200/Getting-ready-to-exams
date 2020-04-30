namespace EnglishTest.Models
{
    public class SentenceAnswer : IAnswer
    {
        public readonly string First;
        public readonly string[] Second;
        public readonly string Word;
        public readonly string Answer;
        public readonly string UserAnswer;

        public SentenceAnswer(string first, string second, string word, string answer, string userAnswer)
        {
            First = first;
            Second = second.Split('_');
            Word = word;
            Answer = answer;
            UserAnswer = userAnswer;
        }

        public bool IsRight()
        {
            return Answer == UserAnswer;
        }
    }
}
