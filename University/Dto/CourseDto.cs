using System.ComponentModel.DataAnnotations.Schema;
using University.Models;

namespace University.Dto
{
    public class CourseDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public int DepartmentId { get; set; }

        public List<IFormFile> Files { get; set; }

        public IEnumerable<FileToApi> FileToApis { get; set; } 
            = new List<FileToApi>();
    }
}
