using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        public int UserRolId { get; set; }
        [JsonIgnore]
        public virtual UserRol UserRol { get; set; }
        public string UserName { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
       // public int IdRol { get; set; }
        public string Password { get; set; }

        public string EncryptedPassword { get; set; }
        public string EncryptedToken { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public int FailedConsecutiveLogins { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}

