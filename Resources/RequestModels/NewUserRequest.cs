using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.RequestModels
{
    public class NewUserRequest
    {
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public string UserName { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int IdRol { get; set; }
        public string Password { get; set; }

        public User ToUser()
        {
            var user = new User();


            user.UserRolId = IdRol;
            user.UserName = UserName;
            user.Password = Password;
            user.Email = Email;
            user.Id = Id;
            user.IdWeb = IdWeb;
            user.InsertDate = DateTime.Now;
            user.UpdateDate = DateTime.Now;
            user.IsActive = true;

            return user;
        }
    }
}

