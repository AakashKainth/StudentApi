using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Index()
        {
            var stdData = await _studentDB.Students.ToListAsync();
            return View(stdData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await _studentDB.Students.AddAsync(std);
                await _studentDB.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(std);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _studentDB.Students == null)
            {
                return NotFound();
            }
            
            var stdData = await _studentDB.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(stdData == null)
            {
                return NotFound();
            }
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
