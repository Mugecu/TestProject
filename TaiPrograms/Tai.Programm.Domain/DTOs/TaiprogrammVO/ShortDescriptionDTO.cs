using TaiProgramms.Entities.ValueObjects;

namespace TaiProgramms.DTO
{
    public class ShortDescriptionDTO
    {
        public string BriefDescription { get; set; }

        public ShortDescriptionDTO ToDto(ShortDescription model) 
        {
            if (model == null) return default;

            BriefDescription = model.BriefDescription;

            return this;
        }

        public ShortDescription ToModel()
            => new ShortDescription(BriefDescription);
    }
}
