using Tai.Authentications.Entities.ValueObjects;

namespace Tai.Authentications.DTO.UsersVO
{
    public class UserNameSurnameDTO
    {
        public string Name { get; set;  }
        public string Surname { get; set;  }

        public UserNameSurnameDTO ToDto(UserNameSurname model) 
        {
            Name = model.Name;
            Surname = model.Surname;

            return this;
        }

        public UserNameSurname ToModel()
            => new UserNameSurname(Name, Surname);
    }
}
