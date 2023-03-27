using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        
        public int UserId { get; set; }
        [JsonIgnore]
       
        public virtual User User { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ProductPrice { get; set; }
        //public int Quantity { get; set; }
        //public int TotalProductPrice { get; set; }
        public int Amount { get; set; }
        public int TotalPrice { get; set; }
        public bool IsPayed { get; set; }
        public bool IsDelivered { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
