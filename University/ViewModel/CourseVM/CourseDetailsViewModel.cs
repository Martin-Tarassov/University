using System.ComponentModel.DataAnnotations;

namespace University.ViewModel.CourseVM
{
    public class CourseDetailsViewModel
    {
        [Display(Name = "Number")]
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        public CourseDepartmentIndexViewModel? Department { get; set; }

        public List<FileToApiViewModel> Files { get; set; } = new List<FileToApiViewModel>();
    }

    public class FileToApiViewModel
    {
        public Guid Id { get; set; }
        public string? ExistingFilePath { get; set; }
    }
}