using ApiTiqets.IService;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace ApiTiqets.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        [HttpPost(Name = "InsertProduct")]
        public int Post([FromBody] Product product)
        {
            return _productService.InsertProduct(product);
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
