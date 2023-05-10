namespace Domain.RequestFeatures;

public class MemberParameters : RequestParameters
{
    public MemberParameters() => OrderBy = "id";

    public string? SearchTerm { get; set; }

}
