namespace University.Dto
{
    public class FileToApiDto
    {
        public Guid Id { get; set; }
        public string? ExistingFilePath { get; set; }
        public Guid? CourseId { get; set; }
    }
}
