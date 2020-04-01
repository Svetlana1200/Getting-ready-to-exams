using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnglishTest.Models;
using System.Collections.Generic;

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
            return ShowNextTask(training);
        }

        public async Task<ActionResult> GetImage(string id)
        {
            var image = await db.GetImage(id);
            if (image == null)
            {
                return NotFound();
            }
            return File(image, "image/jpg");
        }

        public IActionResult ShowNextTask(Training training)
        {
            training.Tasks.MoveNext();
            return View("TestView", training);
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
