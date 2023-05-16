using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;

namespace Application.Commands.Tenants;

public sealed class UpdateTenantCommandValidator : AbstractValidator<UpdateTenantCommand>
{
    public UpdateTenantCommandValidator()
    {
        RuleFor(x => x.Tenant.Name).NotEmpty().WithMessage("Tenant Name is required.");
        RuleFor(x => x.Tenant.Name).MaximumLength(100).WithMessage("Tenant Name is too long (100 chars max).");
    }

    public override ValidationResult Validate(ValidationContext<UpdateTenantCommand> context)
    {
        return context.InstanceToValidate.Tenant is null
            ? new ValidationResult(new[] { new ValidationFailure("TenantForUpdateDto",
                "TenantForUpdateDto object is null") })
            : base.Validate(context);
    }
}
