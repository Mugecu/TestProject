using TaiProgramms.Entities.ValueObjects;

namespace TaiProgramms.DTO
{
    public class DescriptionDTO
    {
        public string DescriptionText { get; set; }

        public DescriptionDTO ToDto(Description model)
        {
            if (model == null) return default;

            DescriptionText = model.DescriptionText;

            return this;
        }

        public Description ToModel()
            => new Description(DescriptionText);
    }
}
