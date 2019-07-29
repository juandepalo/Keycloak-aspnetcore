namespace sampleWebApi.Services
{
    public interface IUserManagementService
    {
          bool IsValidUser(string username, string password);
    }
}