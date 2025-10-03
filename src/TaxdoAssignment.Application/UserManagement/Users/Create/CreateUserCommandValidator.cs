using FluentValidation;

namespace TaxdoAssignment.Application;

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Password)
            .MinimumLength(8)
            .MaximumLength(15)
            .WithMessage("Password length must be between 8 and 15 characters.");
    }
}
