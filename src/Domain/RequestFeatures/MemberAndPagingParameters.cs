namespace Domain.RequestFeatures;

public class MemberAndPagingParameters : PagingParameters
{
    public string? SearchTerm { get; set; }
    public string? OrderBy { get; set; }

}
