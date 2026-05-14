using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.ViewModel
{
    public class StudentIndexViewModel
    {
        public int Id { get; set; }

       
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{LastName}, {FirstMidName}";

        //[Display(Name = "Full Name")]
        //public string Fullname
        //{
        //    get
        //    {
        //        return $"{LastName}, {FirstMidName}";
        //    }
        //}
    }
}