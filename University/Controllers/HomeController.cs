using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using University.Data;
using University.Models;
using University.ViewModel;

namespace University.Controllers
{
    public class HomeController : Controller
    {
        private readonly UniversityContext _context;

        public HomeController
            (
                UniversityContext context
            )
        {
            _context = context;
        }

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

        public async Task<IActionResult> About()
        {
            IQueryable<EnrollmentDateGroupViewModel> data =
                from student in _context.Students
                group student by student.EnrollmentDate
                into dateGroup
                select new EnrollmentDateGroupViewModel()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count(),
                };

            //Teha About vaade, mis kuvab üliõpilaste arvu registreerimise kuupäeva järgi.
            return View(await data.AsNoTracking().ToListAsync());
        }
        
    }

}