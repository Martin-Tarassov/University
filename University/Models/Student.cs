
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; }

        [Column("FirstName")]
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
