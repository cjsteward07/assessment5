using Assessment_5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assessment_5.Controllers
{
    public class HomeController : Controller
    {
        PersonRepository repo;

        public HomeController()
        {
            repo = new PersonRepository();
        }

        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    repo = new PersonRepository();

        //    _logger = logger;
        //}

        public IActionResult Index()
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

        public ActionResult List()
        {
            return View(repo.GetMockPersons());
        }

        public ActionResult GetAge()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetAge(IFormCollection collection)
        {
            try
            {
                PersonViewModel newPerson = new PersonViewModel()
                {
                    Age = int.Parse(collection["Age"]),
                    UserName = collection["UserName"],
                    CanDrink = true,
                CanDrive = true
                };

                repo.CreatePerson(newPerson);
                return RedirectToAction(nameof(List));
            }

            catch
            {
                return View();
            }
        }
    }
}