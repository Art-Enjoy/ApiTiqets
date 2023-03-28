using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class NewProductForm
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Product ToProductItem()
        {
            Product productItem = new Product();
            productItem.Title = Title;
            productItem.Price = Price;
            return productItem;
        }
    }
}
