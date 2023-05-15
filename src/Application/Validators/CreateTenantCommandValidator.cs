using Application.Commands.Tenants;
using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;

namespace Application.Validators;

public sealed class CreateTenantCommandValidator : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantCommandValidator()
    {
        RuleFor(x => x.Tenant.Name).NotEmpty().WithMessage("Tenant Name is required.");
        RuleFor(x => x.Tenant.Name).MaximumLength(100).WithMessage("Tenant Name is too long (100 chars max).");
    }

    public override ValidationResult Validate(ValidationContext<CreateTenantCommand> context)
    {
        return context.InstanceToValidate.Tenant is null
            ? new ValidationResult(new[] { new ValidationFailure("TenantForCreationDto",
                "TenantForCreationDto object is null") })
            : base.Validate(context);
    }
}
