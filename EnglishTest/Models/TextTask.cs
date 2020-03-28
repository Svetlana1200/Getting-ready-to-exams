using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EnglishTest.Models
{
    public class TextTask : ITask
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Text { get; set; }
        [Display(Name = "Answers")]
        public string[] Answer { get; set; }
        [Display(Name = "Points")]
        public int Points { get; set; }
        public string ImageId { get; set; }

        public bool HasImage()
        {
            return !string.IsNullOrWhiteSpace(ImageId);
        }

        public string GetTask()
        {
            return Text;
        }
    }
}
