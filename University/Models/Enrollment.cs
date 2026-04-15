namespace University.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }

    }
}
