using Common.Entities;
using Tai.Authentications.Guards;

namespace Tai.Authentications.Entities.ValueObjects
{
    public class UserEmail : ValueObject<UserEmail>
    {
        public string EmailName { get; }
        public string DomainName { get; }
        private UserEmail() { }
        internal UserEmail(string emailName, string domainName)
        {
            EmailName = Guard.CheckStringValueOnNullEmptyAndWhiteSpace(emailName, "Пустое название почты");
            DomainName = Guard.CheckStringValueOnNullEmptyAndWhiteSpace( domainName, "Пустое доменное имя.");
        }

        public UserEmail ChangeEmail(string emailName, string domainName)
            => new UserEmail(emailName, domainName);

        protected override bool EqualsCore(UserEmail valueObject)
            => EmailName == valueObject.EmailName 
                && DomainName == valueObject.DomainName;

        protected override int GetHashCodeCore()
            => GetHashCode();
    }
}
