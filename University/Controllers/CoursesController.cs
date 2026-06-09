using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using University.Data;
using University.Models;
using University.ViewModel.CourseVM;
using University.ViewModel;

namespace University.Controllers
{
    public class CoursesController : Controller
    {
        private readonly UniversityContext _context;

        public CoursesController(UniversityContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var courses = _context.Courses
                .Select(c => new CourseIndexViewModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    Title = c.Title,
                    DepartmentId = c.DepartmentId,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Department.DepartmentName
                    }
                })
                .ToList();

            return View(courses);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var course = await _context.Courses
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.CourseId == id);

            if (course == null) return NotFound();

            var vm = new CourseUpdateViewModel
            {
                CourseId = course.CourseId,
                Credits = course.Credits,
                Title = course.Title,
                Department = new CourseDepartmentIndexViewModel
                {
                    DepartmentName = course.Department.DepartmentName
                },
                DepartmentList = new SelectList(_context.Department, "DepartmentId", "DepartmentName", course.DepartmentId)
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CourseUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var course = new Course
                {
                    Id = vm.CourseId,
                    CourseId = vm.CourseId,
                    Title = vm.Title,
                    Name = vm.Title,
                    Credits = vm.Credits,
                    DepartmentId = vm.DepartmentId
                };

                _context.Update(course);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.DepartmentList = new SelectList(_context.Department, "DepartmentId", "DepartmentName", vm.DepartmentId);
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Where(c => c.CourseId == id)
                .Select(c => new CourseDetailsViewModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    Title = c.Title,
                    DepartmentId = c.DepartmentId,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Department.DepartmentName
                    }
                })
                .FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
    }
}
