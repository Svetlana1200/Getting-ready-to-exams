using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishTest.Models
{
    public class SentenceTask : ITask
    {
        public const int MaxCount = 2;
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string First { get; set; }
        public string Second { get; set; }
        public string Word { get; set; }
        public string Answer { get; set; }

        public IAnswer CheckUserAnswer(string userAnswer)
        {
            return new SentenceAnswer(First, Second, Word, Answer, MaxCount, userAnswer);
        }
    }
}