using ApiTiqets.IService;
using ApiTiqets.Service;
using Entities.Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO.Compression;
using System.Web.Http.Cors;

namespace ApiTiqets.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        public ProductController(ILogger<ProductController> logger, IProductService productService, IFileService fileService)
        {
            _logger = logger;
            _productService = productService;
            _fileService = fileService;
        }
        //[HttpPost(Name = "InsertProduct")]
        //public int Post([FromBody] Product product)
        //{
        //    return _productService.InsertProduct(product);

        [HttpPost(Name = "PostProductFile")]
        
        public int PostProductFile([FromForm] NewProductRequestB newProductRequest)
        {
            try
            {
                var fileItem = new FileItem();

                fileItem.Id = 0;
                fileItem.Title = newProductRequest.File.FileName;
                fileItem.InsertDate = DateTime.Now;
                fileItem.UpdateDate = DateTime.Now;
                if (newProductRequest.File.ContentType == "image/jpeg")
                {
                    fileItem.FileExtension = Enums.FileExtensionEnum.JPG;
                }
                else if (newProductRequest.File.ContentType == "image/png")
                {
                    fileItem.FileExtension = Enums.FileExtensionEnum.PGN;
                }
                else
                {
                    throw new InvalidDataException();
                }

                using (var stream = new MemoryStream())
                {
                    newProductRequest.File.CopyTo(stream);
                    fileItem.Content = stream.ToArray();
                }

                // fileItem.FileExtension = newProductRequest.Base64FileModel.FileExtension;
                //fileItem.Content = Convert.FromBase64String(newProductRequest.Base64FileModel.Content);

                var fileId = _fileService.InsertFile(fileItem);

                var productData = JsonConvert.DeserializeObject<Product>(newProductRequest.ProductDataString);
                var productItem = productData.ToProductItem();
                productItem.IdPhotoFile = fileId;
                // var product = newProductRequest.Product.ToProductItem();
                // product.IdPhotoFile = fileId;
                return _productService.InsertProduct(productItem);
            }
            catch (Exception)
            {
                throw;
            }

        
        }

        [HttpPost(Name = "PostBase64")]
        public int PostBase64([FromBody] NewProductBase64Request newProductBase64RequestModel)
        {
            try
            {
                var fileItem = new FileItem();

                fileItem.Title = newProductBase64RequestModel.Base64FileModel.FileName;
                fileItem.InsertDate = DateTime.Now;
                fileItem.UpdateDate = DateTime.Now;
                if (newProductBase64RequestModel.Base64FileModel.Extension == "image/jpeg")
                {
                    fileItem.FileExtension = Enums.FileExtensionEnum.JPG;
                }
                else if (newProductBase64RequestModel.Base64FileModel.Extension == "image/png")
                {
                    fileItem.FileExtension = Enums.FileExtensionEnum.PGN;
                }
                else
                {
                    throw new InvalidDataException();
                }
                fileItem.Content = Convert.FromBase64String(newProductBase64RequestModel.Base64FileModel.Base64FileContent);

                var fileId = _fileService.InsertFile(fileItem);

                var productItem = newProductBase64RequestModel.Product.ToProductItem();
                productItem.IdPhotoFile = fileId;

                return _productService.InsertProduct(productItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet(Name = "GetAllFilesAsZip")]
        public IActionResult GetAllFilesAsZip()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    _fileService.GetAllFiles().ForEach(file =>
                    {
                        var entry = zip.CreateEntry(file.Title);
                        using (var fileStream = new MemoryStream(file.Content))
                        using (var entryStream = entry.Open())
                        {
                            fileStream.CopyTo(entryStream);
                        }
                    });
                }
                return File(ms.ToArray(), "application/zip", "images.zip");
            }
        }
        [HttpGet(Name = "GetAllBase64List")]
        public List<Base64FileModel> GetAllBase64List()
        {
            var fileList = _fileService.GetAllFiles();

            List<Base64FileModel> base64FileList = new List<Base64FileModel>();

            foreach (var file in fileList)
            {
                Base64FileModel base64FileModel = new Base64FileModel();

                base64FileModel.FileName = file.Title;
                base64FileModel.Base64FileContent = file.Base64Content;
                if (file.FileExtension == Enums.FileExtensionEnum.JPG)
                {
                    base64FileModel.Extension = "image/jpeg";
                }
                else if (file.FileExtension == Enums.FileExtensionEnum.PGN)
                {
                    base64FileModel.Extension = "image/png";
                }
                else
                {
                    throw new NotImplementedException();
                }

                base64FileList.Add(base64FileModel);
            }

            return base64FileList;
        }

        [HttpGet(Name = "GetFullProductsInfo")]
        public List<FullProductInfoModel> GetFullProductsInfo()
        {
            var productsList = _productService.GetAllProducts();
            var fileList = _fileService.GetAllFiles();

            List<FullProductInfoModel> resultList = new List<FullProductInfoModel>();

            foreach (var prod in productsList)
            {
                FullProductInfoModel resultItem = new FullProductInfoModel();

                resultItem.ProductItem = prod;

                var fileItem = fileList.Where(f => f.Id == prod.IdPhotoFile).First();

                Base64FileModel base64FileModel = new Base64FileModel();

                base64FileModel.FileName = fileItem.Title;
                base64FileModel.Base64FileContent = fileItem.Base64Content;
                if (fileItem.FileExtension == Enums.FileExtensionEnum.JPG)
                {
                    base64FileModel.Extension = "image/jpeg";
                }
                else if (fileItem.FileExtension == Enums.FileExtensionEnum.PGN)
                {
                    base64FileModel.Extension = "image/png";
                }
                else
                {
                    throw new NotImplementedException();
                }

                resultItem.Base64FileModel = base64FileModel;

                resultList.Add(resultItem);
            }

            return resultList;
        }
        [HttpPatch(Name = "PatchProduct")]
        public int Put([FromBody] Product product)
        {
            return _productService.PatchProduct(product);
        }

        [HttpGet(Name = "GetProduct")]
        //nombreSitio.com/nombreController/id
        public List<Product> Get()
        {
            return _productService.GetProduct();
        }


        [HttpDelete(Name = "DeleteProduct")]
        public void DeleteById(int id)
        {
            _productService.DeleteProductById(id);
        }
    }

}
