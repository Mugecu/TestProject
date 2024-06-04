using Tai.Authentications.Entities.ValueObjects;

namespace Tai.Authentications.DTO.UsersVO
{
    public class UserPasswordDTO
    {
        public string Password { get;  set; }

        public UserPasswordDTO? ToDto(UserPassword model)
        {
            Password= model.Password;
            return this;
        }

        public UserPassword ToModel()
            => new UserPassword(Password);
    }
}
