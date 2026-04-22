using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models;
using University.ViewModel;


namespace University.Controllers
{
    public class StudentController : Controller
    {
        private readonly UniversityContext _context;

        public StudentController(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            //leiame kõik student'id ja teisendame need StudentIndexViewModel'iks
            //miks peab kasutama await?
            //kui me kasutame await, siis me ootame kuni päring on lõpetatud
            //ja saame tulemuse, enne kui me jätkame koodi täitmist

            var result = await _context.Students
               .Select(s => new ViewModel.StudentIndexViewModel
               {
                    Id = s.Id,
                    LastName = s.LastName,
                    FirstMidName = s.FirstMidName,
                    EnrollmentDate = s.EnrollmentDate
                   //miks kasutame ToListAsync()?
                   //kui me kasutame ToListAsync(), siis me saame tulemuse listina
               }).ToListAsync();

          return View(result);
        }




        public async Task<IActionResult> Details(int? id)
        {
           
            //Kui id on null, siis tagastame NotFound() tulemuse
            if (id == null)
            {
                return NotFound();
            }

            //Leiame student’i id järgi
            var student = await _context.Students
                //Include lubab objekti kasutada objekti sees
                .Include(s => s.Enrollments)
                //kui tahad uuesti objekti kasutada objekti sees, siis kasutad ThenInclude
                .ThenInclude(e => e.Course)
                //andmeid ei salvestata vahemällu ja ei jälgita
                .AsNoTracking()
                //tagastabesimese elemendi andmetest, mis on tingimuses välja toodud
                .FirstOrDefaultAsync(m => m.Id == id);
            var vm = new StudentDetailsViewModel
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = student.EnrollmentDate,            
                //miks kasutasime ?? - vaikiva väärtuse annab e default väärtus, kui muutuja on tühi (null)
                //või mitte defineeritud. Annab enne vasakpoolse väärtuse, kui see ei ole nult. Kui on null,
                //siis annab parempoolse väärtuse.
                EnrollmentsVm = (student.Enrollments ?? Enumerable.Empty<Enrollment>())
                     .Select(x => new EnrollmentViewModel
                     {
                         CourseId = x.CourseId,
                         Grade = x.Grade,
                         CourseVm = new CourseViewModel
                         {
                            CourseId = x.Course?.CourseId ?? 0,
                            Title = x.Course?.Title,
                            Credits = x.Course?.Credits ?? 0
                         }
                     }).ToArray()
            };

            //Kui student on null, siis tagastame NotFound() tulemuse
            if (student == null)
            {
                return NotFound();
            }
           
            //Kui student on leitud, siis tagastame View(vm) tulemused
            return View(vm);
        }
        //GET: Student/Create
        //see meetod tagastab vaate, kus saab luua uue student'i
        public IActionResult Create()
        {
            return View();
        }
    }
}
