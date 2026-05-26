using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get;  set; }
        public string Title { get; set; }
        public int Credits { get;  set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}