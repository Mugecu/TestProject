using Tai.Authentications.Entities.ValueObjects;

namespace Tai.Authentications.DTO.UsersVO
{
    public class UserEmailDTO
    {
        public string EmailName { get; set; }
        public string DomainName { get; set;  }

        public UserEmailDTO ToDto(UserEmail model)
        {
            EmailName= model.EmailName;
            DomainName= model.DomainName;

            return this;
        }

        public UserEmail ToModel()
            => new UserEmail(EmailName, DomainName);
    }
}
