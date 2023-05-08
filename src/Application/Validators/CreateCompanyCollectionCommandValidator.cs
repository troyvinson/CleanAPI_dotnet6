using Application.Commands.Companies;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Validators;

public sealed class CreateCompanyCollectionCommandValidator : AbstractValidator<CreateCompanyCollectionCommand>
{
	public CreateCompanyCollectionCommandValidator()
	{
		RuleForEach(c => c.CompanyCollection).ChildRules(c =>
		{
            c.RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            c.RuleFor(x => x.Name).MaximumLength(60).WithMessage("Name is too long (60 chars max).");
            c.RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
            c.RuleFor(x => x.Address).MaximumLength(60).WithMessage("Address is too long (60 chars max).");
            c.RuleFor(x => x.Country).NotEmpty().WithMessage("Name is required.");
        });
	}

	public override ValidationResult Validate(ValidationContext<CreateCompanyCollectionCommand> context)
	{
		return context.InstanceToValidate.CompanyCollection is null
			? new ValidationResult(new[] { new ValidationFailure("CompanyForCreationDto",
				"CompanyForCreationDto object is null") })
			: base.Validate(context);
	}
}
