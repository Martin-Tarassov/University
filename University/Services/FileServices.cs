using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Dto;
using University.Models;


namespace University.Services
{
    public class FileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly UniversityContext _context;

        public FileServices
            (
                IHostEnvironment webHost,
                UniversityContext context
            )
        {
            _webHost = webHost;
            _context = context;
        }



        public void FilesToApi(CourseDto dto, Course domain)
        {
            //tingimus, kui File ei ole null või on vähemalt rohkem, kui 0 faili, siis hakkab midagi tegema
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_webHost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\");
                }
                foreach (var file in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_webHost.ContentRootPath, "wwwroot", "multipleFileUpload");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);

                        FileToApi path = new FileToApi
                        {
                            Id = Guid.NewGuid(),
                            ExistingFilePath = uniqueFileName,
                            CourseId = domain.CourseId
                        };
                        _context.FileToApis.Add(path);
                    }
                }
            }
        }
        public async Task<FileToApi> RemoveImageFromApi(FileToApiDto dto)
        {
            //kui soovin kustutada, siis pean läbi Id pildi ülesse otsima
            var imageId = await _context.FileToApis
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            //nüüd otsib faili ülesse apis ja see kustutatakse ära
            var filePath = _webHost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\"
                + imageId.ExistingFilePath;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.FileToApis.Remove(imageId);
            await _context.SaveChangesAsync();

            return null;
            
        }

    }
}
