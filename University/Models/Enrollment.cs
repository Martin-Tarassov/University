namespace University.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int CourseId { get; internal set; }
        public int StudentID { get; set; }
        public int StudentId { get; internal set; }   
        public Grade? Grade { get; set; }

    }
}
