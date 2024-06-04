using Common.Entities;

namespace Estimations.Domain.Entities.ValueObjects
{
    internal class Evaluation : ValueObject<Evaluation>
    {
        internal byte? Mark { get; init; }

        protected override bool EqualsCore(Evaluation valueObject)
            => Mark == valueObject.Mark;

        protected override int GetHashCodeCore()
            => GetHashCode();
    }
}
