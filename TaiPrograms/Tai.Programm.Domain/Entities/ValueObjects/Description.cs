using Common.Entities;

namespace TaiProgramms.Entities.ValueObjects
{
    public class Description : ValueObject<Description>
    {
        public string DescriptionText { get; }

        public Description(string descriptionText)
        {
            DescriptionText = descriptionText;
        }

        protected override bool EqualsCore(Description valueObject)
            => DescriptionText == valueObject.DescriptionText;

        protected override int GetHashCodeCore()
            => DescriptionText.GetHashCode();
    }
}
