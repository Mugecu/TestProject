using Common.Interfaces;
using Estimations.Domain.Entities;

namespace Estimations.Domain.DTOs
{
    public class EstimationDTO : IBaseDTO<Estimation, EstimationDTO>
    {
        public Guid? Id { get; set; }
        public Guid ProgramId { get; set; }
        public Guid UserId { get; set; }
        public EvaluationDTO Evaluation { get; set; }
        public FeedbackDTO Feedback { get; set; }

        public EstimationDTO ToDto(Estimation model)
        {
            if(model == null)
                return default(EstimationDTO);

            Id = model.Id;
            ProgramId = model.ProgramId;
            UserId = model.UserId;
            Evaluation = new EvaluationDTO().ToDto(model.Evaluation);
            Feedback = new FeedbackDTO().ToDto(model?.Feedback);

            return this;
        }

        public Estimation ToModel()
            => Estimation.Create(Id, ProgramId, UserId, Evaluation.ToModel(), Feedback.ToModel());
    }
}
