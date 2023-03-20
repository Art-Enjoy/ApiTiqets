using ApiTiqets.IService;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Resources.RequestModels;
using System.Security.Authentication;

namespace ApiTiqets.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private ISecurityService _securityService;
        private IUserService _userService;
        public UserController(ISecurityService securityService, IUserService userService)

        {

            _securityService = securityService;
            _userService = userService;
        }
        [HttpPost(Name = "InsertUser")]
        public int Post([FromHeader] string userName, [FromHeader] string userPassword, [FromBody] NewUserRequest newUserRequest)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);
            if (validCredentials == true)
            {
                return _userService.InsertUser(newUserRequest);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetAllUsers")]
        public List<User> GetAll([FromHeader] string userName, [FromHeader] string userPassword)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);
            if (validCredentials == true)
            {
                return _userService.GetAllUsers();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModifyUser")]
        public void Patch([FromHeader] string userName, [FromHeader] string userPassword, [FromBody] User user)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);
            if (validCredentials == true)
            {
                _userService.UpdateUser(user);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "DeleteUser")]
        public void Delete([FromHeader] string userName, [FromHeader] string userPassword, [FromQuery] int id)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);
            if (validCredentials == true)
            {
                _userService.DeleteUser(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }


    }
}


