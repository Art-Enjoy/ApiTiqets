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
    public class SecurityLogic : ISecurityLogic
    {
        private readonly ServiceContext _serviceContext;
        public SecurityLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public bool ValidateUserCredentials(string userName, string userPassWord, int idRol)
        {
            var selectedUser = _serviceContext.Set<User>()
                                .Where(u => u.UserName == userName
                                    && u.Password == userPassWord
                                    && u.UserRolId == idRol).FirstOrDefault();

            if (selectedUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
    }

