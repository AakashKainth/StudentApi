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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await _studentDB.Students.AddAsync(std);
                await _studentDB.SaveChangesAsync();
                TempData["Create_Message"] = "Student added successfully";
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _studentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = await _studentDB.Students.FindAsync(id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Student std)
        {
            if (id == null || id != std.Id)
            {
                return BadRequest();
            }

            var existingStudent = await _studentDB.Students.FindAsync(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingStudent.FirstName = std.FirstName;
                existingStudent.LastName = std.LastName;
                existingStudent.Email = std.Email;
                existingStudent.Standard = std.Standard;

                _studentDB.Students.Update(existingStudent);
                await _studentDB.SaveChangesAsync();
                TempData["Update_Message"] = "Student updated successfully";
                return RedirectToAction("Index");
            }
            return View(std);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _studentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = await _studentDB.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var stdData = await _studentDB.Students.FindAsync(id);
            if (stdData == null)
            {
                return NotFound();
            }

            _studentDB.Students.Remove(stdData);
            await _studentDB.SaveChangesAsync();
            TempData["Delete_Message"] = "Student deleted successfully";
            return RedirectToAction("Index");
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
