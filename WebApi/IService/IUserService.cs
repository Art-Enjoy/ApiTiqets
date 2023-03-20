using Entities.Entities;
using Resources.RequestModels;

namespace ApiTiqets.IService
{
    public interface IUserService
    {
        int InsertUser(NewUserRequest newProductRequest);
        void UpdateUser(User user);
        void DeleteUser(int id);
        List<User> GetAllUsers();

    }
}
