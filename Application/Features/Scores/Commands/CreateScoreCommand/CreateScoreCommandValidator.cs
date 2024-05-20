using FluentValidation;

namespace Application.Features.Scores.Commands.CreateScoreCommand
{
    public class CreateScoreCommandValidator : AbstractValidator<CreateScoreCommand>
    {
        public CreateScoreCommandValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("La propiedad {PropertyName} no puede estar vacia.")
                .MaximumLength(50).WithMessage("La propiedad {PropertyName} ({PropertyValue}) no puede exceder {MaxLength} caracteres.");

            RuleFor(s => s.Value)
                .NotEmpty().WithMessage("La propiedad {PropertyName} no puede estar vacia.");

            RuleFor(s => s.IdStudent)
                .NotEmpty().WithMessage("La propiedad {PropertyName} no puede estar vacia.");

            RuleFor(s => s.IdTeacher)
                .NotEmpty().WithMessage("La propiedad {PropertyName} no puede estar vacia.");
        }
    }
}
