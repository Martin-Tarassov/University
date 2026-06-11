using University.Dto;
using University.Models;
using University.ViewModel.CourseVM;

namespace University.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(CourseCreateViewModel vm, Course domain);
        Task<FileToApi?> RemoveImageFromApi(FileToApiDto dto);
    }
}