using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;

namespace Application.Features.Users.Commands;

public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.User.GivenName).NotEmpty().WithMessage("Given Name is required.");
        RuleFor(x => x.User.GivenName).MaximumLength(60).WithMessage("Given Name is too long (60 chars max).");

        RuleFor(x => x.User.Surname).NotEmpty().WithMessage("Surname is required.");
        RuleFor(x => x.User.Surname).MaximumLength(60).WithMessage("Surname is too long (60 chars max).");

        RuleFor(x => x.User.Email).NotEmpty().WithMessage("Email is required.");
        RuleFor(x => x.User.Email).MaximumLength(255).WithMessage("Email is too long (255 chars max).");
        RuleFor(x => x.User.Email).Must(BeAValidEmailAddress).WithMessage("Invalid email format.");

        RuleFor(x => x.User.UserName).NotEmpty().WithMessage("Username is required.");
        RuleFor(x => x.User.UserName).MaximumLength(60).WithMessage("Username is too long (60 chars max).");

        RuleFor(x => x.User.PhoneNumber).Must(BeAValidPhoneNumber!).WithMessage("Invalid phone number format.");

    }

    private bool BeAValidPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber))
            return false;

        return Regex.IsMatch(phoneNumber, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
    }

    private bool BeAValidEmailAddress(string emailAddress)
    {
        if (string.IsNullOrEmpty(emailAddress))
            return false;

        return Regex.IsMatch(emailAddress, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
    }

    public override ValidationResult Validate(ValidationContext<RegisterUserCommand> context)
    {
        return context.InstanceToValidate.User is null
            ? new ValidationResult(new[] { new ValidationFailure("UserForCreationDto",
                "UserForCreationDto object is null") })
            : base.Validate(context);
    }
}
