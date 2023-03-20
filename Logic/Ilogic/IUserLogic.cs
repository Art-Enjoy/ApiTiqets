using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Ilogic
{
    public interface IUserLogic
    {
        int InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        List<User> GetAllUsers();
    }
}
