using Tai.Authentications.Interfaces;

namespace Tai.Authentications.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public DateTime GetDateTimeService()
            => new DateTime();
    }
}
