using Entities.Entities;

namespace ApiTiqets.IService
{
    public interface IFileService
    {
        int InsertFile(FileItem fileItem);
        
        void DeleteFile(int id);
        FileItem GetFileById(int id);
    }
}
