using ApiTiqets.IService;
using ApiTiqets.Service;
using Entities.Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace ApiTiqets.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        //[HttpPost(Name = "InsertProduct")]
        //public int Post([FromBody] Product product)
        //{
        //    return _productService.InsertProduct(product);

        [HttpPost(Name = "PostProductB")]
        
        public int PostProductB([FromForm] NewProductRequestB newProductRequest)
        {
            try
            {
                var fileItem = new FileItem();

                fileItem.Id = 0;
                fileItem.Title = newProductRequest.Base64FileModel.FileName;
                fileItem.InsertDate = DateTime.Now;
                fileItem.UpdateDate = DateTime.Now;
                fileItem.FileExtension = newProductRequest.Base64FileModel.FileExtension;
                fileItem.Content = Convert.FromBase64String(newProductRequest.Base64FileModel.Content);

                var fileId = _fileService.InsertFile(fileItem);

                var product = newProductRequest.Product.ToProductItem();
                product.IdPhotoFile = fileId;
                return _productService.InsertProduct(product);
            }
            catch (Exception)
            {
                throw;
            }
        
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
