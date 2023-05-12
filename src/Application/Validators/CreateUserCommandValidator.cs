using Application.Commands.Users;
using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;

namespace Application.Validators;

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.User.GivenName).NotEmpty().WithMessage("Given Name is required.");
        RuleFor(x => x.User.GivenName).MaximumLength(60).WithMessage("Given Name is too long (60 chars max).");
        RuleFor(x => x.User.Surname).NotEmpty().WithMessage("Surname is required.");
        RuleFor(x => x.User.Surname).MaximumLength(60).WithMessage("Surname is too long (60 chars max).");
        RuleFor(x => x.User.Email).NotEmpty().WithMessage("Email is required.");
        RuleFor(x => x.User.Email).MaximumLength(255).WithMessage("Email is too long (255 chars max).");
        RuleFor(x => x.User.Username).NotEmpty().WithMessage("Username is required.");
        RuleFor(x => x.User.Username).MaximumLength(60).WithMessage("Username is too long (60 chars max).");
        RuleFor(x => x.User.PhoneNumber).Must(BeAValidPhoneNumber!).WithMessage("Invalid phone number format.");

    }

    private bool BeAValidPhoneNumber(string phoneNumber)
    {
        return Regex.IsMatch(phoneNumber, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
    }

    public override ValidationResult Validate(ValidationContext<CreateUserCommand> context)
    {
        return context.InstanceToValidate.User is null
            ? new ValidationResult(new[] { new ValidationFailure("UserForCreationDto",
                "UserForCreationDto object is null") })
            : base.Validate(context);
    }
}
