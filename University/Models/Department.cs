using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }

        //? tähendab, et see väli võib olla null, st see ei ole kohustuslik
        public int? InstructorId { get; set; }

        public Instructor Administrator { get; set; }
        public ICollection<Course> Course { get; set; }
    }
}
