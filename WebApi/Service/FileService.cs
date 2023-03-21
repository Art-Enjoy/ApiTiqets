using ApiTiqets.IService;
using Data;
using Entities.Entities;

namespace ApiTiqets.Service
{
    public class FileService : IFileService
    {
        private readonly ServiceContext _serviceContext;
        public FileService(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public int InsertFile(FileItem fileItem)
        {
            try
            {
                _serviceContext.Files.Add(fileItem);
                _serviceContext.SaveChanges();
                return fileItem.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public void DeleteFile(int id)
        {
            throw new NotImplementedException();
        }

        public FileItem GetFileById(int id)
        {
            var file = _serviceContext.Set<FileItem>().Where(f => f.Id == id).FirstOrDefault();
            if (file != null)
            {
                return file;
            }
            else
            {
                throw new Exception("No se encontró el archivo.");
            }
        }

        
    }
}

