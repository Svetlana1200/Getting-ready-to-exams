using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishTest.Models
{
    public class ImageTask : ITask
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string View { get; set; }
        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }
        public string[] Answer { get; set; }
        public string ImageId { get; set; }

        public ImageTask()
        {
            View = "ImageTaskView";
        }

        public bool UserAnswerIsRight(string[] userAnswer)
        {
            return userAnswer[0] == Answer[0];
        }
    }
}
