using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnglishTest.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson.Serialization;

namespace EnglishTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskService db;
        private readonly Dictionary<string, Type> taskTypes = new Dictionary<string, Type>
        {
            { "sentences", typeof(SentenceTask) },
            { "sentences2", typeof(SentenceTask)},
            { "texts", typeof(TextTask) },
            { "images", typeof(ImageTask) }
        };

        private readonly Dictionary<string, Type> userTraining = new Dictionary<string, Type>
        {
            { "all", typeof(AllTasksTraining) },
            { "sentences", typeof(SentencesTraining) },
            { "texts", typeof(TextsTraining) },
            { "images", typeof(ImageTraining) }
        };

        private readonly Dictionary<string, Type> userContition = new Dictionary<string, Type>
        {
            { "oneMistake", typeof(OneMistakeTrainingEndCondition) },
            { "timer", typeof(TimerTrainingEndCondition) },
            { "end", typeof(EndTasksTrainingEndCondition) }
        };

        private readonly Dictionary<Type, string> taskViews = new Dictionary<Type, string>
        {
            { typeof(SentenceTask), "SentenceTaskView" },
            { typeof(TextTask), "TextTaskView" },
            { typeof(ImageTask), "ImageTaskView" },
            { typeof(SentenceAnswer), "SentenceAnswerView" },
            { typeof(TextAnswer), "TextAnswerView" },
            { typeof(ImageAnswer), "ImageAnswerView" }
        };

        public HomeController(TaskService context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StartTest(IFormCollection answer)
        {
            var trainingType = userTraining[answer["userTrainig"]];
            var conditionType = userContition[answer["userCondition"]];
            var level = answer["userLevel"].ToString();
            var training = (Training)Activator.CreateInstance(trainingType, level,
                            (ITrainingEndCondition)Activator.CreateInstance(conditionType));
            training.CreateTasks(db);
            HttpContext.Session.Set("training", training);

            return ShowNextTask();
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
            var training = HttpContext.Session.Get<Training>("training");
            training.MoveToNextTask();
            var task = GetCurrentTask(training);
            SetSessionParameters(training);
            
            return View("TaskView", task);
        }

        public IActionResult ShowResults()
        {
            var training = HttpContext.Session.Get<Training>("training");
            return View("Results", training.Results);
        }

        [HttpPost]
        public IActionResult CheckAnswer(IFormCollection answer)
        {
            var training = HttpContext.Session.Get<Training>("training");
            var task = GetCurrentTask(training);

            ViewBag.Answer = answer["userAnswer"];
            var answerModel = task.CheckUserAnswer(answer["userAnswer"]);
            training.ChangeCountCorrectOrIncorrectTasks(answerModel.IsRight(), answerModel.Count);
            SetSessionParameters(training);

            return View("AnswerView", answerModel);
        }

        private void SetSessionParameters(Training training)
        {
            ViewBag.TaskNumber = training.СurrentIndex;
            ViewBag.TotalNumber = training.Tasks.Count;
            ViewBag.TaskViews = taskViews;
            ViewBag.IsTrainingFinish = training.isFinish;
            HttpContext.Session.Set("training", training);
        }

        private ITask GetCurrentTask(Training training)
        {
            var taskBSON = db.GetTaskById(training.CurrentTaskCollection, training.CurrentTaskId);
            return (ITask)BsonSerializer.Deserialize(taskBSON, taskTypes[training.CurrentTaskCollection]);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
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
