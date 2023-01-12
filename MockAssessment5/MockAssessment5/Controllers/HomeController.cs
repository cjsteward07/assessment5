using Microsoft.AspNetCore.Mvc;
using MockAssessment5.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace MockAssessment5.Controllers
{
    public class HomeController : Controller
    {
         List<PersonViewModel> _person;
         private readonly ILogger<HomeController> _logger;

         public HomeController(ILogger<HomeController> logger)
        {
             _person = new List<PersonViewModel>();
            _logger = logger;
        }
        //public HomeController()
        //{
        //    _person = new List<PersonViewModel>();

        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Result(PersonViewModel _person)
        {

            return View(_person);
        }

        public IActionResult GetAge()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult GetAge(IFormCollection collection)
        {
            
            PersonViewModel person = new PersonViewModel()
            {
                Age = int.Parse(collection["Age"]),
                UserName = collection["UserName"]

            };

            if (person.Age >= 16)
            {
                person.CanDrive = true;
            }
            if (person.Age >= 21)
            {
                person.CanDrink = true;
            }
            _person.Add(person);

            return View("Result", _person);
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