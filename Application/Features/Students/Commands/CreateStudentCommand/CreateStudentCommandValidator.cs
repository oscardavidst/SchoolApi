using FluentValidation;

namespace Application.Features.Students.Commands.CreateStudentCommand
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("La propiedad {PropertyName} no puede estar vacia.")
                .MaximumLength(50).WithMessage("La propiedad {PropertyName} no puede exceder {MaxLength} caracteres.");
        }
    }
}
