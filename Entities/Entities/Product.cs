using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Product
    {
        public Product()
        {
            IsActive = true;
            IsPublic = true;
        }
        public int Id { get; set; }
      
        public string Title { get; set; }
        
        public string Location { get; set; }
        public decimal Price { get; set; }
        public decimal Units { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublic { get; private set; }

        //public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
