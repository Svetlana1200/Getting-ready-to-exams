﻿namespace EnglishTest.Models
{
    public class ImageAnswer : IAnswer
    {
        public const int MaxCount = 1;
        public string Question;
        public string Script;
        public readonly string First;
        public readonly string Second;
        public readonly string Third;
        public readonly string ImageId;
        public readonly string RightAnswer;
        public readonly string UserAnswer;
        public readonly string[] Classes = new string[3];
        public int Count { get; private set; }

        public ImageAnswer(string first, string second, string third, string imageId,
            string rightAnswer, string scriptHTML, string question, string userAnswer)
        {
            First = first;
            Second = second;
            Third = third;
            ImageId = imageId;
            RightAnswer = rightAnswer;
            Script = scriptHTML;
            Question = question;
            UserAnswer = userAnswer;
            Classes[int.Parse(userAnswer) - 1] = "wrong";
            Classes[int.Parse(rightAnswer) - 1] = "right";
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
