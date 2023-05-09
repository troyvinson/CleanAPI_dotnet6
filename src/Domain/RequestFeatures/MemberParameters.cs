namespace Domain.RequestFeatures;

public class MemberParameters : RequestParameters
{
    public MemberParameters() => OrderBy = "name";

    public uint MinAge { get; set; }
	public uint MaxAge { get; set; } = int.MaxValue;

	public bool ValidAgeRange => MaxAge > MinAge;

	public string? SearchTerm { get; set; }

}
