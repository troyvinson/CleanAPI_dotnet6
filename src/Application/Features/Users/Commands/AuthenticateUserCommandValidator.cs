using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;

namespace Application.Features.Users.Commands;

public sealed class AuthenticateCommandValidator : AbstractValidator<AuthenticateUserCommand>
{
    public AuthenticateCommandValidator()
    {
        RuleFor(x => x.User.UserName).NotEmpty().WithMessage("User Name is required.");
        RuleFor(x => x.User.Password).NotEmpty().WithMessage("Password is required.");
    }

    public override ValidationResult Validate(ValidationContext<AuthenticateUserCommand> context)
    {
        return context.InstanceToValidate.User is null
            ? new ValidationResult(new[] { new ValidationFailure("UserForAuthenticationDto",
                "UserForAuthenticationDto object is null") })
            : base.Validate(context);
    }
}
