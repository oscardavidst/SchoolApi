using FluentValidation;

namespace Application.Features.Teachers.Commands.UpdateTeacherCommand
{
    public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
    {
        public UpdateTeacherCommandValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty().WithMessage("La propiedad {PropertyName} no puede estar vacia.");

            RuleFor(t => t.Name)
                .NotEmpty().WithMessage("La propiedad {PropertyName} no puede estar vacia.")
                .MaximumLength(50).WithMessage("La propiedad {PropertyName} no puede exceder {MaxLength} caracteres.");
        }
    }
}
