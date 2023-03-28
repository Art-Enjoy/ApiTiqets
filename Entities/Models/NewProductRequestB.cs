using Entities.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class NewProductRequestB
    {
        public IFormFile File { get; set; }
        public string ProductDataString { get; set; }
    }
}
