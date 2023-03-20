using ApiTiqets.IService;
using Data;
using Logic.Ilogic;

namespace ApiTiqets.Service
{
    public class SecurityService : ISecurityService
    {
        //private readonly ServiceContext _serviceContext;
        private readonly ISecurityLogic _securityLogic;
        public SecurityService(ServiceContext serviceContext, ISecurityLogic securityLogic)
        {
            //_serviceContext = serviceContext;
            _securityLogic = securityLogic;
        }
        public bool ValidateUserCredentials(string userName, string userPassWord, int idRol)
        {
         

            return _securityLogic.ValidateUserCredentials(userName, userPassWord, idRol);

        }
    }
    
    }

