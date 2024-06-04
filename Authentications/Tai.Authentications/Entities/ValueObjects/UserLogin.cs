using Common.Entities;
using Tai.Authentications.Guards;

namespace Tai.Authentications.Entities.ValueObjects
{
    public class UserLogin : ValueObject<UserLogin>
    {
        public string Login { get; }
        private UserLogin() { }
        internal UserLogin(string login)
        {
            Login = Guard.CheckStringValueOnNullEmptyAndWhiteSpace(login, "Пустое имя логина.");
        }

        public UserLogin ChangeLogin(string login)
            => new UserLogin(login);

        protected override bool EqualsCore(UserLogin valueObject)
            => Login == valueObject.Login;

        protected override int GetHashCodeCore()
            => Login.GetHashCode();
    }
}
