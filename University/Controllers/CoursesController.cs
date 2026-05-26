using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.ViewModel.CourseVM;

namespace University.Controllers
{
    public class CoursesController : Controller
    {
        private readonly UniversityContext _context;

        public CoursesController(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();

            var viewModel = courses.Select(c => new CourseIndexViewModel
            {
                CourseId = c.CourseId,
                Title = c.Title,
                Credits = c.Credits,
                DepartmentId = c.DepartmentId,
                Department = c.Department
            }).ToList();

            return View(viewModel);
        }
    }
}
