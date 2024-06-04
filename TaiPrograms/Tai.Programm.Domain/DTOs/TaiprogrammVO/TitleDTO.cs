using TaiProgramms.Entities.ValueObjects;

namespace TaiProgramms.DTO
{
    public class TitleDTO
    {
        public string Title { get; set; }

        public TitleDTO ToDto(Title model)
        {
            if (model == null) return default;

            Title = model.Name;

            return this;
        }

        public Title ToModel()
            => new Title(Title);
    }
}
