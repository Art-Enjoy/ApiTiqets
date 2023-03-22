namespace ApiTiqets.IService
{
    public interface IUserSecurityService
    {
        string GenerateAuthorizationToken(string userName, string userPassword);
        bool ValidateUserToken(string authorization, string controller, string action, string method);
    }
}
