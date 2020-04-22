using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishTest.Models
{
    public class SentenceTask : ITask
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string View { get; set; }
        public string First { get; set; }
        public string Second { get; set; }
        public string Word { get; set; }
        public string Answer { get; set; }

        public SentenceTask()
        {
            View = "SentenceTaskView";
        }

        public bool CheckUserAnswer(string userAnswer)
        {
            return userAnswer == Answer;
        }
    }
}