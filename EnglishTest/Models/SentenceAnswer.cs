using System.Collections.Generic;

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

        private readonly Dictionary<string, List<string>> verbContractions = new Dictionary<string, List<string>>()
        {
            { "'m", new List<string>(){" am" } },
            { "'re", new List<string>(){" are" } },
            { "'s", new List<string>(){" is", " has" } },
            { "n't", new List<string>(){" not" } },
            { "can't", new List<string>(){"cannot" } },
            { "won't", new List<string>(){"will not" } },
            { "'d", new List<string>(){" would", " had" } },
            { "'ve", new List<string>(){" have" } },
            { "'ll", new List<string>(){" will"} }
        };

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

            if (string.Compare(RightAnswer, UserAnswer.Trim(), true) == 0)
            {
                Count = MaxCount;
                return true;
            }
            else
            {
                foreach (var contraction in verbContractions)
                    if (UserAnswer.Contains(contraction.Key))
                        foreach (var variant in contraction.Value)
                        {
                            var userAnswer = UserAnswer.Replace(contraction.Key, variant).Trim();
                            if (string.Compare(RightAnswer, userAnswer, true) == 0)
                            {
                                Count = MaxCount;
                                return true;
                            }
                        }
            }
            return false;
        }
    }
}
