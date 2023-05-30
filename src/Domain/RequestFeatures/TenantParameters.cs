namespace Domain.RequestFeatures;

public class TenantParameters : BaseParameters
{
    public override string? OrderBy { get; set; } = "Name";
}
