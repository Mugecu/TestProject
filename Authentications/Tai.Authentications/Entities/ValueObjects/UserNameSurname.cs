using Tai.Authentications.Guards;

namespace Tai.Authentications.Entities.ValueObjects
{
    public class UserNameSurname
    {
        public string Name { get;}
        public string Surname { get;}
        private UserNameSurname() { } 

        internal UserNameSurname( string name, string surname)
        {
            Name = Guard.CheckStringValueOnNullEmptyAndWhiteSpace(name, "Задайте корректное имя пользователя."); 
            Surname = Guard.CheckStringValueOnNullEmptyAndWhiteSpace(name, "Задайте корректное фамилию пользователя.");
        }

        public UserNameSurname ChangeUserName(string newUserName)
            => new UserNameSurname(
                    Guard.CheckStringValueOnNullEmptyAndWhiteSpace(newUserName, "Задайте корректное имя пользователя."),
                    Surname);

        public UserNameSurname ChangeUserSurname(string newUserSurname)
            => new UserNameSurname(
                    Name,
                    Guard.CheckStringValueOnNullEmptyAndWhiteSpace(newUserSurname, "Задайте корректную фамилию пользователя."));
    }
}
