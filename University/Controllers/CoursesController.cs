using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models;
using University.ViewModel.CourseVM;
using University.ServiceInterface;
using University.Dto;

namespace University.Controllers
{
    public class CourseController : Controller
    {
        private readonly UniversityContext _context;
        private readonly IFileServices _fileServices;

        public CourseController(UniversityContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<IActionResult> Index()
        {
            var course = await _context.Courses
                .Select(c => new CourseIndexViewModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    Title = c.Title,
                    DepartmentId = c.DepartmentId,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Department != null ? c.Department.DepartmentName : null
                    }
                })
                .ToListAsync();

            return View(course);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vm = await _context.Courses
                .Where(c => c.CourseId == id)
                .Select(c => new CourseUpdateViewModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    Title = c.Title,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Department != null ? c.Department.DepartmentName : null
                    }
                })
                .FirstOrDefaultAsync();

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CourseUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var course = await _context.Courses.FindAsync(vm.CourseId);
                if (course == null)
                {
                    return NotFound();
                }

                course.Title = vm.Title;
                course.Name = vm.Title;
                course.Credits = vm.Credits;

                _context.Update(course);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            PopulateDepartmentDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateViewModel vm)
        {
            Course course = new Course();

            course.Id = vm.CourseId;
            course.CourseId = vm.CourseId;
            course.Title = vm.Title;
            course.Name = vm.Title;
            course.Credits = vm.Credits;
            course.DepartmentId = vm.DepartmentId;

            _context.Add(course);
            await _context.SaveChangesAsync();

            _fileServices.FilesToApi(vm, course);
            await _context.SaveChangesAsync();

            PopulateDepartmentDropDownList(course.DepartmentId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Department)
                .Include(c => c.FilesToApi)
                .Where(c => c.CourseId == id)
                .Select(c => new CourseDetailsViewModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    Title = c.Title,
                    DepartmentId = c.DepartmentId,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Department != null ? c.Department.DepartmentName : null
                    },
                    Files = c.FilesToApi.Select(f => new FileToApiViewModel
                    {
                        Id = f.Id,
                        ExistingFilePath = f.ExistingFilePath
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Department)
                .Where(c => c.CourseId == id)
                .Select(c => new CourseDeleteViewModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    Title = c.Title,
                    DepartmentId = c.DepartmentId,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Department != null ? c.Department.DepartmentName : null
                    }
                })
                .FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void PopulateDepartmentDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = _context.Departments
                .OrderBy(d => d.DepartmentName)
                .GroupBy(d => d.DepartmentName)
                .Select(g => g.First());

            ViewBag.DepartmentId = new SelectList(departmentsQuery
                .AsNoTracking(), "DepartmentId", "DepartmentName", selectedDepartment);
        }
    }
}