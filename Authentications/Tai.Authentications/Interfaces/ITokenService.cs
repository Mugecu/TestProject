using Tai.Authentications.Entities;

namespace Tai.Authentications.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, User user);
    }
}
