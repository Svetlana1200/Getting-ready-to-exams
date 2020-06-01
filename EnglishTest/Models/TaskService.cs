using System;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EnglishTest.Models
{
    public class TaskService
    {
        private IMongoDatabase database;
        private readonly Dictionary<string, List<BsonDocument>> databaseCache = new Dictionary<string, List<BsonDocument>>();
        private readonly List<string> collectionNames = new List<string>() {
            "texts", "images", "sentences", "texts2", "sentences2" };

        public TaskService()
        {
            var user = Environment.GetEnvironmentVariable("MONGODB_USERNAME");
            var password = Environment.GetEnvironmentVariable("MONGODB_PASSWORD");
            var connectionString = $"mongodb+srv://{user}:{password}@englishtasks-n4smy.gcp.mongodb.net/" +
                "englishTest?retryWrites=true&w=majority";

            var connection = new MongoUrlBuilder(connectionString);
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(connection.DatabaseName);

            ReloadDBCache();
        }

        public List<string> GetTasksIds(string collection, int tasksNumber)
        {
            var rnd = new Random();
            return databaseCache[collection]
                .OrderBy(x => rnd.Next())
                .Take(tasksNumber)
                .Select(x => x["_id"].ToString())
                .ToList();
        }

        public BsonDocument GetTaskById(string collection, string taskId)
        {
            return databaseCache[collection]
                .Where(x => x["_id"] == new ObjectId(taskId))
                .First();
        }

        private void ReloadDBCache()
        { 
            foreach (var name in collectionNames)
            {
                databaseCache[name] = database
                    .GetCollection<BsonDocument>(name)
                    .Find(new BsonDocument())
                    .ToList();
            }
        }
    }
}
