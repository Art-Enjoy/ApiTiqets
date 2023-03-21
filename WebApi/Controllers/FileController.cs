using ApiTiqets.IService;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Mime;

namespace ApiTiqets.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FileController
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost(Name = "PostFile")]
        public int PostFile([FromForm] FileUploadModel fileUploadModel)
        {
            try
            {
                var fileItem = new FileItem();
                fileItem.Id = 0;
                fileItem.Name = fileUploadModel.File.FileName;
                fileItem.InsertDate = DateTime.Now;
                fileItem.UpdateDate = DateTime.Now;
                fileItem.FileExtension = fileUploadModel.FileExtension;

                using (var stream = new MemoryStream())
                {
                    fileUploadModel.File.CopyTo(stream);
                    fileItem.Content = stream.ToArray();
                }

                return _fileService.InsertFile(fileItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet(Name = "GetFileById")]
        public FileStreamResult GetFileById(int id)
        {
            try
            {
                var fileItem = _fileService.GetFileById(id);
                var stream = new MemoryStream(fileItem.Content);

                //string
                var mimeType = MediaTypeNames.Image.Jpeg.ToString();

                //someObject
                //var someObject = new MediaTypeHeaderValue(mimeType);

                return new FileStreamResult(stream, new MediaTypeHeaderValue(mimeType))
                {
                    FileDownloadName = fileItem.Name
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}


