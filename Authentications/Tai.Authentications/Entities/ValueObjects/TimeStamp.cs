using Common.Entities;
using Tai.Authentications.Guards;
using Tai.Authentications.Interfaces;

namespace Tai.Authentications.Entities.ValueObjects
{
    public class TimeStamp : ValueObject<TimeStamp>
    {
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; }
        public DateTime LastVisit { get;}
        public DateTime? DeletedAt { get;}
        public IDateTime? _dateTime { get;}

        private TimeStamp() { }

        internal TimeStamp(IDateTime dateTime) 
        {
            _dateTime = dateTime == null 
                ? throw new Exception("Сервис времени не прередан.")
                : dateTime;

            CreatedAt = dateTime.Now;
            LastVisit= dateTime.Now;
        }

        internal TimeStamp(DateTime createdAt, DateTime? updatedAt, DateTime lastVisit, DateTime? deletedAt, IDateTime dateTime)
        {
            CreatedAt = createdAt
                .CheckForCorrectDate(updatedAt.CheckForNullInDate() , "Дата обновления меньше даты создания.")
                .CheckForCorrectDate(lastVisit, "Дата последнего визита меньше даты создания.");

            UpdatedAt = updatedAt;
            LastVisit = lastVisit;
            DeletedAt = deletedAt;
            _dateTime = dateTime;
        }

        protected override bool EqualsCore(TimeStamp valueObject)
            => CreatedAt == valueObject.CreatedAt 
                && UpdatedAt == valueObject.UpdatedAt
                && LastVisit == valueObject.LastVisit
                && DeletedAt == valueObject.DeletedAt;

        protected override int GetHashCodeCore()
            => GetHashCode();

        public TimeStamp SetLastVisit(DateTime lastVisit)
            => new TimeStamp(CreatedAt,UpdatedAt,lastVisit, DeletedAt.Value, _dateTime);

        public void SetUpdateAt(DateTime? updateAt)
            => new TimeStamp(CreatedAt, updateAt, LastVisit, DeletedAt,  _dateTime);
    }
}
