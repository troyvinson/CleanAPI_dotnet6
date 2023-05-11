namespace Domain.RequestFeatures;

public class UserParameters : RequestParameters
{
    public string? OrderBy { get; set; } = "id";

    public string SearchTerm { get; set; } = string.Empty;

}
