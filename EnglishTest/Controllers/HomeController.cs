using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnglishTest.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;

namespace EnglishTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskService db;
        private readonly Dictionary<string, Type> taskTypes = new Dictionary<string, Type>
        {
            { "sentences", typeof(SentenceTask) },
            { "texts", typeof(TextTask) },
            { "images", typeof(ImageTask) }
        };

        public HomeController(TaskService context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> StartTest(IFormCollection answer)
        {
            ITraining training = null;
            Type trainingType = null;
            var userTrainig = answer["userTrainig"];
            if (userTrainig == "all")
            {
                training = new AllTasksTraining(db, new OneMistakeCondition());
                trainingType = typeof(AllTasksTraining);
            }
            else if (userTrainig == "sentences")
            {
                training = new SentencesTraining(db, new OneMistakeCondition());
                trainingType = typeof(SentencesTraining);
            }
            else if (userTrainig == "texts")
            {
                training = new TextsTraining(db, new OneMistakeCondition());
                trainingType = typeof(TextsTraining);
            }
            else if (userTrainig == "images")
            {
                training = new ImageTraining(db, new OneMistakeCondition());
                trainingType = typeof(ImageTraining);
            }
            await training.CreateTasks();
            HttpContext.Session.Set("training", training);
            HttpContext.Session.Set("trainingType", trainingType);

            return ShowNextTask();
        }

        private async void AddTasks<T>(string collection, Dictionary<string, string> tasks)
        {
            var tasksGroup = await db.GetTasksId(collection);
            foreach (var taskId in tasksGroup)
            {
                tasks[taskId] = collection;
            }
        }

        public async Task<ActionResult> GetImage(string id)
        {
            var image = await db.GetImage(id);
            if (image == null)
            {
                return NotFound();
            }
            return File(image, "image/png");
        }

        public IActionResult ShowNextTask()
        {
            var trainingType = HttpContext.Session.Get<Type>("trainingType");
            var training = HttpContext.Session.Get<ITraining>("training", trainingType);
            training.MoveToNextTask();
            var task = GetCurrentTask(training);

            ViewBag.TaskNumber = training.СurrentIndex;
            ViewBag.TotalNumber = training.Tasks.Count;
            HttpContext.Session.Set("training", training);
            return View("TestView", task);
        }

        [HttpPost]
        public IActionResult CheckAnswer(IFormCollection answer)
        {
            var trainingType = HttpContext.Session.Get<Type>("trainingType");
            var training = HttpContext.Session.Get<ITraining>("training", trainingType);
            var task = GetCurrentTask(training);

            ViewBag.Answer = answer["userAnswer"];
            ViewBag.UserAnswerIsRight = task.CheckUserAnswer(answer["userAnswer"]);
            ViewBag.TaskNumber = training.СurrentIndex;
            ViewBag.TotalNumber = training.Tasks.Count;
            return View("TestView", task);
        }

        private ITask GetCurrentTask(ITraining training)
        {
            var taskBSON = db.GetTaskById(training.CurrentTaskCollection, training.CurrentTaskId).Result;
            return (ITask)BsonSerializer.Deserialize(taskBSON, taskTypes[training.CurrentTaskCollection]);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
