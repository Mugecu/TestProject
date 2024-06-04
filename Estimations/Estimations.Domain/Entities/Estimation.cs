using Common.Entities;
using Estimations.Domain.Entities.ValueObjects;

namespace Estimations.Domain.Entities
{
    public sealed class Estimation : AggregateRoot
    {
        public Guid ProgramId { get; set; }
        internal Guid UserId { get; set; }
        internal Evaluation Evaluation { get; set; }
        internal Feedback? Feedback { get; set; }

        protected Estimation() { }

        private Estimation(
            Guid? id,
            Guid programId,
            Guid userId,
            Evaluation evaluation,
            Feedback? feedback)
                : this()
        {
            CheckId(id);
            ProgramId = programId;
            UserId = userId;
            Evaluation = evaluation;
            Feedback = feedback;
        }

        internal static Estimation Create(
            Guid? id,
            Guid programId,
            Guid userId,
            Evaluation evaluation,
            Feedback? feedback)
                => new Estimation(id, programId, userId, evaluation, feedback);

        private void CheckId(Guid? userId)
        {
            if (userId.HasValue)
            {
                Id = userId.Value;
                return;
            }
            GenerateId();
        }
    }
}
