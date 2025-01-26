using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Data;

namespace StudentApi.Controllers
{
    public class HomeController : Controller
    {
        private StudentContext _studentDB;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(StudentContext studentDB)
        {
                _studentDB = studentDB;
        }

        public IActionResult Index()
        {
            var stdData = _studentDB.Students.ToList();
            return View(stdData);
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
