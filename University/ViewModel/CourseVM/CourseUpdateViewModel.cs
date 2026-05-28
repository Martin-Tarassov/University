using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace University.ViewModel.CourseVM
{
    public class CourseUpdateViewModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        public CourseDepartmentIndexViewModel Department { get; set; }

        public SelectList DepartmentList { get; set; }
    }
}