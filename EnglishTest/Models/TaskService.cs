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
            var connectionString = "mongodb://localhost:27017/englishTest";
            var connection = new MongoUrlBuilder(connectionString);
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(connection.DatabaseName);
            gridFS = new GridFSBucket(database);
        }

        public async Task<List<T>> GetTasks<T>(string taskType)
        {
            return await database.GetCollection<T>(taskType).Find(new BsonDocument()).ToListAsync();
        }
    }
}
