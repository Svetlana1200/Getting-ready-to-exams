namespace EnglishTest.Models
{
    public class ImageAnswer : IAnswer
    {
        public const int MaxCount = 1;
        public readonly string First;
        public readonly string Second;
        public readonly string Third;
        public readonly string ImageId;
        public readonly string RightAnswer;
        public readonly string UserAnswer;
        public int Count { get; private set; }

        public ImageAnswer(string first, string second, string third, string imageId,
            string rightAnswer, string userAnswer)
        {
            First = first;
            Second = second;
            Third = third;
            ImageId = imageId;
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
