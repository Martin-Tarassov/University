using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.ViewModel.CourseVM
{
    public class CourseCreateViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ImageViewModel> Image { get; set; }
            = new List<ImageViewModel>();

        public DepartmentViewModel Department { get; set; }
    }

    public class DepartmentViewModel
    {
        public string? Name { get; set; }
    }
}