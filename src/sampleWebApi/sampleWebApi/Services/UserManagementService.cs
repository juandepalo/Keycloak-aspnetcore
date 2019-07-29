namespace sampleWebApi.Services
{
    public class UserManagementService: IUserManagementService
    {
        public bool IsValidUser(string userName , string password)
        {
            return true;
        }
    }
}