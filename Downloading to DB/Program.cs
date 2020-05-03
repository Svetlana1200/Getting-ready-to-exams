using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EnglishTest.DownloadingToDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new ParsingSentencesTask<FormatSentencesTask>().GetTasks();

            var user = Environment.GetEnvironmentVariable("MONGODB_USERNAME");
            var password = Environment.GetEnvironmentVariable("MONGODB_PASSWORD");
            var connectionString = $"mongodb+srv://{user}:{password}@englishtasks-n4smy.gcp.mongodb.net/" +
                "englishTest?retryWrites=true&w=majority";
            var connection = new MongoUrlBuilder(connectionString);
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(connection.DatabaseName);

            AddSentencesDocsToDB(database, "sentences2", tasks).GetAwaiter().GetResult();
        }

        private static async Task AddSentencesDocsToDB(IMongoDatabase db, string collectionName, 
            List<FormatSentencesTask> tasks)
        {
            var collection = db.GetCollection<BsonDocument>(collectionName);

            foreach (var task in tasks)
            {
                var doc = new BsonDocument
                {
                    { "First", task.First},
                    { "Second", string.Join('_', task.Beginning, task.Ending)},
                    { "Word", task.Word},
                    { "Answer", task.Answer}
                };
                await collection.InsertOneAsync(doc);
            }
        }
    }
}
