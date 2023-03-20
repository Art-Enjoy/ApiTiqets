using ApiTiqets.IService;
using Entities.Entities;
using Logic.Ilogic;
using Resources.RequestModels;

namespace ApiTiqets.Service
{
    public class UserService : IUserService

    {
        private readonly IUserLogic _userLogic;
        public UserService(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        public void DeleteUser(int id)
        {
            _userLogic.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            return _userLogic.GetAllUsers();
        }

        public int InsertUser(NewUserRequest newUserRequest)
        {
            var newUser = newUserRequest.ToUser();
            return _userLogic.InsertUser(newUser);
        }

        public void UpdateUser(User user)
        {
            _userLogic.UpdateUser(user);
        }

    }

}
