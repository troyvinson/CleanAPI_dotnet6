namespace Domain.RequestFeatures;

public class MemberParameters
{
    public string? SearchTerm { get; set; }
    public string? OrderBy { get; set; } = "username";

}
