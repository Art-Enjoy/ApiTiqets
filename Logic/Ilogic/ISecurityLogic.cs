using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Ilogic
{
    public interface ISecurityLogic
    {
        bool ValidateUserCredentials(string userName, string userPassWord, int idRol);
    }
}
