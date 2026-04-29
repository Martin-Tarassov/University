using Microsoft.AspNetCore.Mvc;

namespace University.ViewModel
{
    public class StudentDeleteViewModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<EnrollmentViewModel> EnrollmentsVm { get; set; }
    }
}
