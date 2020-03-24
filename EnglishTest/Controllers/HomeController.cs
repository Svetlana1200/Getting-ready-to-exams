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

        public async Task<IActionResult> Index()
        {
            var tasks = new List<ITask>();
            var sentenceTasks = await db.GetTasks<SentenceTask>("sentences");
            var textTasks = await db.GetTasks<TextTask>("texts");
            tasks.AddRange(sentenceTasks);
            tasks.AddRange(textTasks);

            var model = new IndexViewModel { Tasks = tasks };
            return View(model);
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
