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
            var sentensesTasks = new ParsingSentencesTaskB1().GetTasks();
            //var imageTasks = new ParsingImageTask().GetTasks();
            //var textTaskB2 = new ParsingTextTaskB2().GetTasks();

            //var sentensesTasks = new ParsingSentencesTaskB2().GetTasks();
            //var textTasksB1 = new ParsingTextTaskB1().GetTasks();

            var user = Environment.GetEnvironmentVariable("MONGODB_USERNAME");
            var password = Environment.GetEnvironmentVariable("MONGODB_PASSWORD");
            var connectionString = $"mongodb+srv://{user}:{password}@englishtasks-n4smy.gcp.mongodb.net/" +
                "englishTest?retryWrites=true&w=majority";
            var connection = new MongoUrlBuilder(connectionString);
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(connection.DatabaseName);

            //AddSImagesDocsToDB(database, "images", imageTasks).GetAwaiter().GetResult();
            //AddTextsDocsToDB(database, "texts2", textTaskB2).GetAwaiter().GetResult();
            //AddTextsDocsToDB(database, "texts", textTasksB1).GetAwaiter().GetResult();
            //AddSentencesDocsToDB(database, "sentences2", sentensesTasks).GetAwaiter().GetResult();
            AddSentencesDocsToDB(database, "sentences", sentensesTasks).GetAwaiter().GetResult();
        }

        private static async Task AddSImagesDocsToDB(IMongoDatabase db, string collectionName,
            List<FormatImageTask> tasks)
        {
            var collection = db.GetCollection<BsonDocument>(collectionName);

            foreach (var task in tasks)
            {
                var doc = new BsonDocument
                {
                    { "Script", task.ScriptHTML},
                    { "Question", task.Question},
                    { "First", task.First},
                    { "Second", task.Second},
                    { "Third", task.Third},
                    { "Answer", task.Answer}
                };
                await collection.InsertOneAsync(doc);
            }
        }

        private static async Task AddTextsDocsToDB(IMongoDatabase db, string collectionName,
            List<FormatTextTask> tasks)
        {
            var collection = db.GetCollection<BsonDocument>(collectionName);

            foreach (var task in tasks)
            {
                var doc = new BsonDocument
                {
                    { "Text", task.Text},
                    { "Answer", new BsonArray(task.Answers) }
                };
                await collection.InsertOneAsync(doc);
            }
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
