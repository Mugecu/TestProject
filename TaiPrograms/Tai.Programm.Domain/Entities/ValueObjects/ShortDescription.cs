using Common.Entities;
using TaiProgramms.Guards;

namespace TaiProgramms.Entities.ValueObjects
{
    public class ShortDescription : ValueObject<ShortDescription>
    {
        public string BriefDescription { get; }

        public ShortDescription(string briefDescription)
        {
            Guard.CheckStringOnNullOrEmptyOrWhiteSpaseOnly(briefDescription, "Заполните краткое описание программы.");
            BriefDescription = briefDescription;
        }

        protected override bool EqualsCore(ShortDescription valueObject)
            => BriefDescription == valueObject.BriefDescription;

        protected override int GetHashCodeCore()
            => BriefDescription.GetHashCode();
    }
}
