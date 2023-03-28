using ApiTiqets.IService;
using Entities.Entities;
using Logic.Ilogic;

namespace ApiTiqets.Service
{
    public class ProductService : IProductService
    {
        //private readonly IProductService _productService;
        private readonly IProductLogic _productLogic;
        public ProductService(IProductLogic productLogic)
        {
            _productLogic = productLogic;

        }

        public void DeleteProductById(int id)
        {
            _productLogic.DeleteProductById(id);
        }

        public List<Product> GetProduct()
        {
            return _productLogic.GetProduct();
        }
        public List<Product> GetAllProducts()
        {
            return _productLogic.GetAllProducts();
        }
        public int InsertProduct(Product product)
        {
            _productLogic.InsertProduct(product);
            return product.Id;
        }

        public int PatchProduct(Product product)
        {
            _productLogic.PatchProduct(product);
            return product.Id;
        }
    }
}
