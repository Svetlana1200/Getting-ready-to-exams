using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace EnglishTest.Models
{
    public class TaskService
    {
        private IGridFSBucket gridFS;
        private IMongoDatabase database;

        public TaskService()
        {
            var user = Environment.GetEnvironmentVariable("MONGODB_USERNAME");
            var password = Environment.GetEnvironmentVariable("MONGODB_PASSWORD");
            var connectionString = $"mongodb+srv://{user}:{password}@englishtasks-n4smy.gcp.mongodb.net/" +
                "englishTest?retryWrites=true&w=majority";

            var connection = new MongoUrlBuilder(connectionString);
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(connection.DatabaseName);
            gridFS = new GridFSBucket(database);
        }

        public async Task<List<string>> GetTasksId(string taskType)
        {
            var tasksId = new List<string>();
            var collection = await database
                .GetCollection<BsonDocument>(taskType)
                .Find(new BsonDocument())
                .ToListAsync();

            foreach (var task in collection)
            {
                tasksId.Add(task["_id"].ToString());
            }
            return tasksId;
        }

        public async Task<BsonDocument> GetTaskById(string collection, string taskId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(taskId));
            return await database.GetCollection<BsonDocument>(collection).Find(filter).SingleAsync();
        }

        public async Task<byte[]> GetImage(string id)
        {
            return await gridFS.DownloadAsBytesAsync(new ObjectId(id));
        }
    }
}
