using ApiTiqets.IService;
using Entities.Entities;
using Logic.Ilogic;

namespace ApiTiqets.Service
{
    public class RolService : IRolService
    {
        //private readonly IProductService _productService;
        private readonly IRolLogic _rolLogic;
        public RolService(IRolLogic rolLogic)
        {
            _rolLogic = rolLogic;
        }

        public int InsertUserRol(UserRol userRol)
        {
            _rolLogic.InsertUserRol(userRol);
            return userRol.Id;
        }
    }
    

    }

