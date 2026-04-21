using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Data;
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
                .FirstOrDefaultAsync(m => m.Id == id);
            
            var vm = new ViewModel.StudentDetailsViewModel
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = student.EnrollmentDate
            };

            //Kui student on null, siis tagastame NotFound() tulemuse
            if (student == null)
            {
                return NotFound();
            }
           
            //Kui student on leitud, siis tagastame View(vm) tulemused
            return View(vm);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var student = new Models.Student
                {
                    LastName = vm.LastName,
                    FirstMidName = vm.FirstMidName,
                    EnrollmentDate = vm.EnrollmentDate
                };

                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
    }
}
