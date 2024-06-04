using Estimations.Domain.Entities.ValueObjects;

namespace Estimations.Domain.DTOs
{
    public class EvaluationDTO
    {
        public byte? Mark { get; set; }

        internal EvaluationDTO ToDto(Evaluation model)
        {
            if(model == null)
                return default(EvaluationDTO);

            Mark = model.Mark;

            return this;
        }

        internal Evaluation ToModel()
            => new Evaluation() { Mark = Mark };
    }
}
