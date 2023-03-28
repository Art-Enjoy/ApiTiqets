using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class FullProductInfoModel
    {
        public Product ProductItem { get; set; }
        public Base64FileModel Base64FileModel { get; set; }
    }
}
