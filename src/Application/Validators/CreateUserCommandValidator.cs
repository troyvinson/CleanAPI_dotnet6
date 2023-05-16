﻿//using Application.Commands.Users;
//using FluentValidation;
//using FluentValidation.Results;
//using System.Text.RegularExpressions;

//namespace Application.Validators;

//public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
//{
//    public CreateUserCommandValidator()
//    {
//        RuleFor(x => x.User.FirstName).NotEmpty().WithMessage("First Name is required.");
//        RuleFor(x => x.User.FirstName).MaximumLength(60).WithMessage("First Name is too long (60 chars max).");

//        RuleFor(x => x.User.LastName).NotEmpty().WithMessage("Last Name is required.");
//        RuleFor(x => x.User.LastName).MaximumLength(60).WithMessage("Last Name is too long (60 chars max).");

//        RuleFor(x => x.User.Email).NotEmpty().WithMessage("Email is required.");
//        RuleFor(x => x.User.Email).MaximumLength(255).WithMessage("Email is too long (255 chars max).");
//        RuleFor(x => x.User.Email).Must(BeAValidEmailAddress).WithMessage("Invalid email format.");

//        RuleFor(x => x.User.UserName).NotEmpty().WithMessage("UserName is required.");
//        RuleFor(x => x.User.UserName).MaximumLength(60).WithMessage("UserName is too long (60 chars max).");

//        RuleFor(x => x.User.PhoneNumber).Must(BeAValidPhoneNumber!).WithMessage("Invalid phone number format.");

//    }

//    private bool BeAValidPhoneNumber(string phoneNumber)
//    {
//        if (string.IsNullOrEmpty(phoneNumber))
//            return false;

//        return Regex.IsMatch(phoneNumber, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
//    }

//    private bool BeAValidEmailAddress(string emailAddress)
//    {
//        if (string.IsNullOrEmpty(emailAddress))
//            return false;

//        return Regex.IsMatch(emailAddress, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
//    }

//    public override ValidationResult Validate(ValidationContext<CreateUserCommand> context)
//    {
//        return context.InstanceToValidate.User is null
//            ? new ValidationResult(new[] { new ValidationFailure("UserForCreationDto",
//                "UserForCreationDto object is null") })
//            : base.Validate(context);
//    }
//}
