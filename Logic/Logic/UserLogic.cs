using Data;
using Entities.Entities;
using Logic.Ilogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class UserLogic : IUserLogic
    {
       
    
        private readonly ServiceContext _serviceContext;
        public UserLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public void DeleteUser(int id)
        {
            var userToDelete = _serviceContext.Set<User>()
                 .Where(u => u.Id == id).First();

            userToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }

        public List<User> GetAllUsers()
        {
            return _serviceContext.Set<User>()
                .Where(u => u.IsActive == true)
                .ToList();
        }

        public int InsertUser(User userItem)
        {
            if (userItem.IdRol == 1)
            {
                throw new InvalidOperationException();
            };

            _serviceContext.Users.Add(userItem);
            _serviceContext.SaveChanges();
            return userItem.Id;
        }

        public void UpdateUser(User userItem)
        {
            _serviceContext.Users.Update(userItem);

            _serviceContext.SaveChanges();
        }
    }
}

