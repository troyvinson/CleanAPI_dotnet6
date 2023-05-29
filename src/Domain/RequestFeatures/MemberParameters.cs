namespace Domain.RequestFeatures;

public class MemberParameters : BaseParameters
{
    public override string? OrderBy { get; set; } = "username";

}
