using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace EnglishTest.Models
{
    public class SentenceTask : ITask
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string First { get; set; }
        public string Second { get; set; }
        public string Word { get; set; }
        [Display(Name = "Answer")]
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
            return $"{First}\n{Second}\n{Word}";
        }
    }
}
