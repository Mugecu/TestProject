using Common.Entities;
using TaiProgramms.Guards;

namespace TaiProgramms.Entities.ValueObjects
{
    public class Title : ValueObject<Title>
    {
        public string Name { get; }

        public Title(string name)
        {
            Guard.CheckStringOnNullOrEmptyOrWhiteSpaseOnly(name, "Заполните название программы.");
            Name = name;
        }

        protected override bool EqualsCore(Title valueObject)
            => Name == valueObject.Name;

        protected override int GetHashCodeCore()
            => Name.GetHashCode();
    }
}
