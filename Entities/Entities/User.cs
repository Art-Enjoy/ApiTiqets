using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class User
    {
        public User()
        {
            IsActive = true;
        }
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public string UserName { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int IdRol { get; set; }
        public string Password { get; set; }

        private string EncryptedPassword { get; set; }


       // public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}

