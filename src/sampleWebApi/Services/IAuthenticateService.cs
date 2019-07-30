

using sampleWebApi.Models;
namespace sampleWebApi.Services
{
    public interface IAuthenticateService
    {
        bool IsAuthenticated(TokenRequest request, out string token);
    }
}