namespace Domain.RequestFeatures;

public class MemberSearchParameters : RequestParameters
{
    public MemberSearchParameters() => OrderBy = "id";

    public string? SearchTerm { get; set; }

}
