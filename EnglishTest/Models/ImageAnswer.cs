namespace EnglishTest.Models
{
    public class ImageAnswer : IAnswer
    {
        public readonly string First;
        public readonly string Second;
        public readonly string Third;
        public readonly string ImageId;
        public readonly string Answer;
        public readonly string UserAnswer;
        public readonly int MaxCount;
        public int Count { get; private set; }

        public ImageAnswer(string first, string second, string third, string imageId,
            string answer, int maxCount, string userAnswer)
        {
            First = first;
            Second = second;
            Third = third;
            ImageId = imageId;
            Answer = answer;
            UserAnswer = userAnswer;
            MaxCount = maxCount;
        }

        public bool IsRight()
        {
            Count = 0;
            if (Answer == UserAnswer)
            {
                Count = MaxCount;
                return true;
            }
            return false;
        }
    }
}
