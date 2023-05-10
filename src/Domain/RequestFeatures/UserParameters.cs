namespace Domain.RequestFeatures;

public class UserParameters : RequestParameters
{
    public UserParameters()
    {
        OrderBy = "username";
    }

    public string SearchTerm { get; set; } = string.Empty;

}
