using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishTest.Models
{
    public class TextTask : ITask
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Text { get; set; }
        public string[] Answer { get; set; }

        public IAnswer CheckUserAnswer(string userAnswer)
        {
            return new TextAnswer(Text, Answer, userAnswer);
        }
    }
}
