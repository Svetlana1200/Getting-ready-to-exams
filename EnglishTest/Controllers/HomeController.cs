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

        public async Task<IActionResult> StartTest()
        {
            var tasks = new List<ITask>();
            var sentenceTasks = await db.GetTasks<SentenceTask>("sentences");
            var textTasks = await db.GetTasks<TextTask>("texts");
            var imageTasks = await db.GetTasks<ImageTask>("imageTasks");
            tasks.AddRange(imageTasks);
            tasks.AddRange(sentenceTasks);
            tasks.AddRange(textTasks);

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
            ViewBag.UserAnswerIsRight = task.UserAnswerIsRight(answer["userAnswer"]);
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
