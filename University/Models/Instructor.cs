using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }

        public string LastName { get; set; }

        [Column("FirstName")]
        public string FirstMidName { get; set; }

        public DateTime HireDate { get; set; }

        public ICollection<CourseAssignment> CourseAssignments { get; set; }

        public OfficeAssignment OfficeAssignments { get; set; }
    }
}
