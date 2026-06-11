using University.Dto;
using University.Models;

namespace University.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(CourseDto dto, Course domain);
        Task<FileToApi?> RemoveImageFromApi(FileToApiDto dto);
    }
}
