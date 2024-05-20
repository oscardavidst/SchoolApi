using FluentValidation;

namespace Application.Features.Scores.Commands.UpdateScoreCommand
{
    public class UpdateScoreCommandValidator : AbstractValidator<UpdateScoreCommand>
    {
        public UpdateScoreCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty().WithMessage("La propiedad {PropertyName} no puede estar vacia.");

            RuleFor(h => h.Name)
                .NotEmpty().WithMessage("La propiedad {PropertyName} no puede estar vacia.")
                .MaximumLength(60).WithMessage("La propiedad {PropertyName} ({PropertyValue}) no puede exceder {MaxLength} caracteres.");

            RuleFor(h => h.Value)
                .NotEmpty().WithMessage("La propiedad {PropertyName} no puede estar vacia.");

            RuleFor(h => h.IdStudent)
                .NotEmpty().WithMessage("La propiedad {PropertyName} no puede estar vacia.");

            RuleFor(h => h.IdTeacher)
                .NotEmpty().WithMessage("La propiedad {PropertyName} no puede estar vacia.");
        }
    }
}
