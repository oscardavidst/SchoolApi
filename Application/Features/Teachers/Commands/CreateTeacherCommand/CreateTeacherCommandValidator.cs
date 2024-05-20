using FluentValidation;

namespace Application.Features.Teachers.Commands.CreateTeacherCommand
{
    public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
    {
        public CreateTeacherCommandValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty().WithMessage("La propiedad {PropertyName} no puede estar vacia.")
                .MaximumLength(50).WithMessage("La propiedad {PropertyName} ({PropertyValue}) no puede exceder {MaxLength} caracteres.");
        }
    }
}
