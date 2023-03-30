using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Ilogic
{
    public interface IProductLogic
    {
        void DeleteProductById(int Id);
        List<Product> GetProduct();
        List<Product> GetAllProducts();
        void InsertProduct(Product product);
        void PatchProduct(Product product);
    }
}

