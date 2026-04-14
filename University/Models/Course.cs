namespace University.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; internal set; }
        public string Title { get; internal set; }
        public int Credits { get; internal set; }
    }
}