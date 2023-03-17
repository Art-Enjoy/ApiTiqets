using Entities.Entities;

namespace ApiTiqets.IService
{
    public interface IProductService
    {

        void DeleteProductById(int id);
        List<Product> GetProduct();
        int InsertProduct(Product product);
        int PatchProduct(Product product);
    }
}