using Common.Entities;
using Tai.Authentications.Guards;

namespace Tai.Authentications.Entities.ValueObjects
{
    public class UserPassword : ValueObject<UserPassword>
    {
        // добавить шифрование.
        public string Password { get;}
        private UserPassword() { }
        internal UserPassword(string password)
        {
            Guard.CheckStringOnNullEmptyAndWhiteSpace(password, "Пустой пароль");
            Guard.CheckForPasswordLength(password, "Недостаточная длинна пароля.");
            Password = password;
        }

        public UserPassword ChangePassword(string password)
            => new UserPassword(password);

        protected override bool EqualsCore(UserPassword valueObject)
            => Password == valueObject.Password;

        protected override int GetHashCodeCore()
            => Password.GetHashCode();
    }
}
