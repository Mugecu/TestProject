using Tai.Authentications.DTO.UsersVO;
using Tai.Authentications.Entities;

namespace Tai.Authentications.DTO
{
    public class UserDTO
    {
        Guid? UserId { get; set; }
        public UserNameSurnameDTO UserNameSurname { get; set; }
        public UserLoginDTO UserLogin { get; set; }
        public UserEmailDTO UserEmail { get; set; }
        public UserPasswordDTO UserPassword { get; set; }
        public TimeStampDTO TimeStamp { get; set; }

        public UserDTO ToDto(User model)
        {
            UserId = model.Id;
            UserNameSurname = new UserNameSurnameDTO().ToDto(model.UserNameSurname);
            UserLogin = new UserLoginDTO().ToDto(model.UserLogin);
            UserEmail = new UserEmailDTO().ToDto(model.UserEmail);
            UserPassword = new UserPasswordDTO().ToDto(model.UserPassword);
            TimeStamp = new TimeStampDTO().ToDto(model.TimeStamp);

            return this;
        }

        public User ToModel()
            => User.Create(
                    UserId,
                    UserNameSurname.ToModel(),
                    UserLogin.ToModel(),
                    UserEmail.ToModel(),
                    UserPassword.ToModel(),
                    TimeStamp?.ToModel());
    }
}
