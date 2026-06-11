using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        [NotMapped]
        public string Name
        {
            get => DepartmentName;
            set => DepartmentName = value;
        }

        [Column(TypeName = "money")]
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }

        //? tähendab, et see väli võib olla null, st see ei ole kohustuslik
        public int? InstructorId { get; set; }

        public Instructor Administrator { get; set; }
        public ICollection<Course> Course { get; set; }
    }
}
