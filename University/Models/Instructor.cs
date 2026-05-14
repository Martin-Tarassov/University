using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Instructor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public int DepartmentId { get; set; }

        public Department Departments { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }

}
