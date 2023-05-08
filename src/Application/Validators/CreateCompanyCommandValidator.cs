using Application.Commands.Companies;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Validators;

public sealed class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
	public CreateCompanyCommandValidator()
	{
        RuleFor(x => x.Company.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Company.Name).MaximumLength(60).WithMessage("Name is too long (60 chars max).");
        RuleFor(x => x.Company.Address).NotEmpty().WithMessage("Address is required.");
        RuleFor(x => x.Company.Address).MaximumLength(60).WithMessage("Address is too long (60 chars max).");
        RuleFor(x => x.Company.Country).NotEmpty().WithMessage("Country is required.");
    }

    public override ValidationResult Validate(ValidationContext<CreateCompanyCommand> context)
	{
		return context.InstanceToValidate.Company is null
			? new ValidationResult(new[] { new ValidationFailure("CompanyForCreationDto",
				"CompanyForCreationDto object is null") })
			: base.Validate(context);
	}
}
