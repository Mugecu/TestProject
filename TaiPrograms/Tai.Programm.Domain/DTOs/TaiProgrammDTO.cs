using TaiProgramms.Entities;

namespace TaiProgramms.DTO
{
    public class TaiProgrammDTO
    {
        public Guid Id { get; set; }
        public TitleDTO Title { get; set; }
        public ShortDescriptionDTO ShortDescription { get; set; }
        public DescriptionDTO Description { get; set; }

        public TaiProgrammDTO ToDto(TaiProgramm model)
        {
            if (model == null) return default;

            Title = new TitleDTO().ToDto( model.Title);
            ShortDescription = new ShortDescriptionDTO().ToDto(model.ShortDescription);
            Description = new DescriptionDTO().ToDto(model.Description);

            return this;
        }

        public TaiProgramm ToModel()
            => TaiProgramm.Create(Id, Title.ToModel(), ShortDescription.ToModel(), Description.ToModel());
    }
}
