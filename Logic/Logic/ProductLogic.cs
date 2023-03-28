using Data;
using Entities.Entities;
using Logic.Ilogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class ProductLogic : BaseContextLogic, IProductLogic
    {
        public ProductLogic(ServiceContext serviceContext) : base(serviceContext) {  }
        public void DeleteProductById(int Id)
        {
            var chooseProduct = _serviceContext.Set<Product>().Where(p => p.Id == Id).First();
            chooseProduct.IsActive = false;
            _serviceContext.SaveChanges();
        }

        public void InsertProduct(Product product)
        {
            _serviceContext.Products.Add(product);
            _serviceContext.SaveChanges();
        }

        public void PatchProduct(Product product)
        {
            _serviceContext.Products.Update(product);
            _serviceContext.SaveChanges();
        }

        public List<Product> GetProduct()
        {
            return _serviceContext.Set<Product>().ToList();

        }
        public List<Product> GetAllProducts()
        {
            return _serviceContext.Set<Product>().ToList();

        }
    }
}

