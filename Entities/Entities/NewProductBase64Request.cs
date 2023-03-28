using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class NewProductBase64Request
    {
        public Base64FileModel Base64FileModel { get; set; }
        public ProductData ProductData { get; set; }
    }
}
