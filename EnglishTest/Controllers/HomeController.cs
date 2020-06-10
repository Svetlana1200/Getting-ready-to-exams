using System;
using System.Diagnostics;
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
            { "texts2", typeof(TextTask)},
            { "images", typeof(ImageTask) }
        };

        private readonly Dictionary<Parameters.Trainings, Type> userTraining = new Dictionary<Parameters.Trainings, Type>
        {
            { Parameters.Trainings.All, typeof(AllTasksTraining) },
            { Parameters.Trainings.Sentences, typeof(SentencesTraining) },
            { Parameters.Trainings.Texts, typeof(TextsTraining) },
            { Parameters.Trainings.Images, typeof(ImageTraining) }
        };

        private readonly Dictionary<Parameters.Conditions, Type> userContition = new Dictionary<Parameters.Conditions, Type>
        {
            { Parameters.Conditions.OneMistake, typeof(OneMistakeTrainingEndCondition) },
            { Parameters.Conditions.Timer, typeof(TimerTrainingEndCondition) },
            { Parameters.Conditions.End, typeof(EndTasksTrainingEndCondition) }
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
            return View(new Parameters());
        }

        [HttpPost]
        public IActionResult StartTest(Parameters parameters)
        {
            var trainingType = userTraining[parameters.UserTraining];
            var conditionType = userContition[parameters.UserCondition];
            var time = Math.Max(1, parameters.Time);

            ITrainingEndCondition trainingEndCondition = null;
            if (conditionType == typeof(TimerTrainingEndCondition))
                trainingEndCondition = (ITrainingEndCondition)Activator.CreateInstance(conditionType, time);
            else
                trainingEndCondition = (ITrainingEndCondition)Activator.CreateInstance(conditionType);

            var training = (Training)Activator.CreateInstance(
                trainingType, parameters.UserLevel, trainingEndCondition);

            training.CreateTasks(db, parameters.TasksNumber);
            HttpContext.Session.Set("training", training);
            return ShowNextTask();
        }

        public IActionResult ShowNextTask()
        {
            var training = HttpContext.Session.Get<Training>("training");
            if (training.wasAnsweredCurrentTask)
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

        public IActionResult Contact()
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
