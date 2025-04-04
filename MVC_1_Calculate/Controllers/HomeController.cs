using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_1_Calculate.Models;

namespace MVC_1_Calculate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sum()
        {
            return View(0);
        }

        [HttpPost]
        public IActionResult Sum(int number1, int number2)
        {
            int result = number1 + number2;

            ViewBag.FirstNumber = number1;
            ViewBag.SecondNumber = number2;

            return View(result);
        }

        public IActionResult Subtract()
        {
            return View(0);
        }

        [HttpPost]
        public IActionResult Subtract(IFormCollection collection)
        {
            int number1 = 0;
            int number2 = 0;

            int.TryParse(collection["number1"], out number1);
            int.TryParse(collection["number2"], out number2);

            int result = number1 - number2;

            ViewBag.FirstNumber = number1;
            ViewBag.SecondNumber = number2;

            return View(result);
        }

        public IActionResult Multiply()
        {
            Numbers numbers = new Numbers();
            return View(numbers);
        }

        [HttpPost]
        public IActionResult Multiply(Numbers numbers)
        {
            numbers.Result = numbers.FirstNumber * numbers.SecondNumber;
            return View(numbers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
