using Tai.Authentications.Entities.ValueObjects;

namespace Tai.Authentications.DTO.UsersVO
{
    public class UserLoginDTO
    {
        public string Login { get; set;  }

        public UserLoginDTO ToDto(UserLogin model)
        {
            Login= model.Login;

            return this;
        }

        public UserLogin ToModel()
            => new UserLogin(Login);
    }
}
