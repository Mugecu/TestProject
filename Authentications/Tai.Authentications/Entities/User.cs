using Common.Entities;
using Tai.Authentications.Entities.ValueObjects;
using Tai.Authentications.Interfaces;

namespace Tai.Authentications.Entities
{
    public class User : AggregateRoot
    {
        public UserNameSurname UserNameSurname { get; set; }
        public UserLogin UserLogin { get; set; }
        public UserEmail UserEmail { get; set; }
        public UserPassword UserPassword { get; set; }
        public TimeStamp? TimeStamp { get; set; }

        protected User() { }

        private User(
            Guid? userId,
            UserNameSurname userNameSurname,
            UserLogin userLogin,
            UserEmail userEmail,
            UserPassword userPassword,
            TimeStamp timeStamp) 
                : this()
        {
            CheckId(userId);
            UserNameSurname = userNameSurname;
            UserLogin = userLogin;
            UserEmail = userEmail;
            UserPassword = userPassword;
            TimeStamp = timeStamp;
        }

        //private User(
        //    Guid? userId,
        //    UserNameSurname userNameSurname,
        //    UserLogin userLogin,
        //    UserEmail userEmail,
        //    UserPassword userPassword,
        //    IDateTime dateTime) 
        //        : this()
        //{
        //    CheckId(userId);
        //    UserNameSurname = userNameSurname;
        //    UserLogin = userLogin;
        //    UserEmail = userEmail;
        //    UserPassword = userPassword;

        //    TimeStamp = new TimeStamp(dateTime);
        //}

        public static User Create(
            Guid? userId,
            UserNameSurname userNameSurname,
            UserLogin userLogin,
            UserEmail userEmail,
            UserPassword userPassword,
            TimeStamp timeStamp)
                => new User(
                            userId,
                            userNameSurname,
                            userLogin,
                            userEmail,
                            userPassword,
                            timeStamp);
                    //: new User(
                    //        userId,
                    //        userNameSurname,
                    //        userLogin,
                    //        userEmail,
                    //        userPassword,
                    //        dateTimeService);

        public void RenameUser(string name, string surname)
            => UserNameSurname = new UserNameSurname(name, surname);

        public void ChangeUserEmail(string emailName, string domainName)
            => UserEmail = new UserEmail(emailName, domainName);

        public void ChangeUserPassword(string password)
            => UserPassword.ChangePassword(password);

        public void ChangeUserLogin(string login)
            => UserLogin.ChangeLogin(login);

        public void SetTimeStamp(IDateTime dateTime)
            => TimeStamp = new TimeStamp(dateTime);

        private void CheckId(Guid? userId)
        {
            if (userId.HasValue)
            {
                Id = userId.Value;
                return;
            }
            GenerateId();
        }
    }
}
