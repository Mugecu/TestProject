using Tai.Authentications.Entities.ValueObjects;

namespace Tai.Authentications.DTO.UsersVO
{
    public class TimeStampDTO
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime LastVisit { get; set; }
        public DateTime? DeletedAt { get; set; }

        public TimeStampDTO ToDto(TimeStamp model)
        {
            CreatedAt = model.CreatedAt;
            UpdatedAt= model.UpdatedAt;
            LastVisit = model.LastVisit;
            DeletedAt = model.DeletedAt;

            return this;
        }

        public TimeStamp ToModel()
            => new TimeStamp(CreatedAt,UpdatedAt, LastVisit, DeletedAt, null);
    }
}
