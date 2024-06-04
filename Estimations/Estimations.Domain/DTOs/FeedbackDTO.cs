using Estimations.Domain.Entities.ValueObjects;

namespace Estimations.Domain.DTOs
{
    public class FeedbackDTO
    {
        public Guid EstimationId { get; set; }
        public string? Text { get; set; }

        internal FeedbackDTO ToDto(Feedback model)
        {
            if (model == null)
                return default(FeedbackDTO);

            EstimationId = model.EstimationId;
            Text = model.Text;

            return this;
        }

        internal Feedback ToModel()
            => Feedback.Create(EstimationId, Text);
    }
}
