using ApiTiqets.IService;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiTiqets.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolController : ControllerBase
    {
        private ISecurityService _securityService;
        private IRolService _rolService;
        private IUserService _userService;
        public RolController(ISecurityService securityService, IRolService rolService)

        {
            _securityService = securityService;
            _rolService = rolService;
        }

        [HttpPost(Name = "InsertRol")]
        public int Post([FromBody] UserRol userRol)
        {
            return _rolService.InsertUserRol(userRol);
        }


    }
}
