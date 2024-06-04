using Common.Entities;
using Estimations.Domain.Guards;

namespace Estimations.Domain.Entities.ValueObjects
{
    internal class Feedback : ValueObject<Feedback>
    {
        internal Guid EstimationId { init; get; } 
        internal string Text { init; get; }

        protected Feedback() { }

        private Feedback(Guid estimationId, string? text)
        {
            text = Guard.CheckIsNullOrWhiteSpace(text);
            // ограничение текста в отзыве на 1000 символов.
            Guard.CheckTextOnMaxLength(text, "Максимальное количество символов равно 1000");
            EstimationId = estimationId;
            Text = text;
        }

        internal static Feedback Create(Guid estimationId, string? text)
            => new Feedback(estimationId, text);

        protected override bool EqualsCore(Feedback valueObject)
            => EstimationId == valueObject.EstimationId 
                && Text == valueObject.Text;

        protected override int GetHashCodeCore()
            => GetHashCode();
    }
}
