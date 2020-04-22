using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnglishTest.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EnglishTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskService db;

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
            var tasks = new List<ITask>();
            var userTrainig = answer["userTrainig"];
            if (userTrainig == "all" || userTrainig == "sentences")
            {
                tasks.AddRange(await db.GetTasks<SentenceTask>("sentences"));
            }
            if (userTrainig == "all" || userTrainig == "texts")
            {
                tasks.AddRange(await db.GetTasks<TextTask>("texts"));
            }
            if (userTrainig == "all" || userTrainig == "imageTasks" )
            {
                tasks.AddRange(await db.GetTasks<ImageTask>("imageTasks"));
            }
            var training = new Training(tasks);
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
            var task = JsonConvert.DeserializeObject(training.CurrentTask, training.CurrentTaskType);
            ViewBag.TaskNumber = training.СurrentIndex + 1;
            ViewBag.TotalNumber = training.Tasks.Count;
            HttpContext.Session.Set("training", training);
            return View("TestView", task);
        }

        [HttpPost]
        public IActionResult CheckAnswer(IFormCollection answer)
        {
            var training = HttpContext.Session.Get<Training>("training");
            var task = (ITask)JsonConvert.DeserializeObject(training.CurrentTask, training.CurrentTaskType);
            ViewBag.Answer = answer["userAnswer"];
            ViewBag.UserAnswerIsRight = task.CheckUserAnswer(answer["userAnswer"]);
            ViewBag.TaskNumber = training.СurrentIndex + 1;
            ViewBag.TotalNumber = training.Tasks.Count;
            return View("TestView", task);
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
