namespace University.Models
{
    public class CourseAssignment
    {
        public int InstructorId { get; set; }

        public int CourseId { get; set; }

        public Instructor Instructors { get; set; }

        public Course Courses { get; set; }

    }
}
