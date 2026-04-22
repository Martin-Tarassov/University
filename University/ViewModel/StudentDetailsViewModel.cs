using University.Models;

namespace University.ViewModel
{
    public class StudentDetailsViewModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public IEnumerable<EnrollmentViewModel> EnrollmentsVm { get; set; }

    }

    public class EnrollmentViewModel
    {
        public int EnrollmentID { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }
        
        public CourseViewModel CourseVm { get; set; }

    }

    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
    }

}
