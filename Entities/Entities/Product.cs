using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        public Guid IdWeb { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]

        public virtual Order Order { get; set; }
        public string Title { get; set; }
        public int IdPhotoFile { get; set; }

        public string Location { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore]
        public decimal Units { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublic { get; private set; }
        

        


    }
}

