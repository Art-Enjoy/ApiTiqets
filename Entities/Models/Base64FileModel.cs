using ApiTiqets.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Base64FileModel
    {
        public string FileName { get; set; }
        public string Content { get; set; }
        public FileExtensionEnum FileExtension { get; set; }
    }
}
