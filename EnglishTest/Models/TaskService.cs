using System;
using System.Linq;
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
        private Dictionary<string, List<BsonDocument>> databaseCache = new Dictionary<string, List<BsonDocument>>();

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

            ReloadDBCache();
        }

        public List<string> GetTasksIds(string collection)
        {
            return databaseCache[collection]
                .Select(x => x["_id"].ToString())
                .ToList();
        }

        public BsonDocument GetTaskById(string collection, string taskId)
        {
            return databaseCache[collection]
                .Where(x => x["_id"] == new ObjectId(taskId))
                .First();
        }

        public async Task<byte[]> GetImage(string id)
        {
            return await gridFS.DownloadAsBytesAsync(new ObjectId(id));
        }

        private void ReloadDBCache()
        {
            var collectionNames = database
                .ListCollectionNames()
                .ToList()
                .Where(x => x != "fs.chunks" && x != "fs.files");

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
