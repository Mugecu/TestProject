using Common.Entities;
using TaiProgramms.Entities.ValueObjects;

namespace TaiProgramms.Entities
{
    public class TaiProgramm :AggregateRoot
    {
        public Title Title { get; private set; }
        public ShortDescription ShortDescription { get; private set; }
        public Description Description { get; private set; }

        public TaiProgramm() { }

        private TaiProgramm(
            Guid? programId,
            Title title,
            ShortDescription shortDescription,
            Description description) 
                : this()
        {
            CheckId(programId);
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
        }

        public static TaiProgramm Create(
            Guid? programId,
            Title title,
            ShortDescription shortDescription,
            Description description)
                => new TaiProgramm(programId, title, shortDescription, description);

        public void ChangeProgrammName(string title)
            => Title = new Title(title);

        public void ChangeShortDescription(string shortDescription)
            => ShortDescription = new ShortDescription(shortDescription);

        public void ChangeDescription(string description)
            => Description = new Description(description);

        //TODO: добавить монаду Options или MayBe. 
        public TaiProgramm UpdateProgramm(string title, string shortDescription, string descripton)
        {
            ChangeProgrammName(title);
            ChangeShortDescription(shortDescription);
            ChangeDescription(descripton);
            return this;
        }

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
