namespace Domain.RequestFeatures;

public class EmployeeParameters : RequestParameters
{
    public string? OrderBy { get; set; } = "name";

    public uint MinAge { get; set; }
    public uint MaxAge { get; set; } = int.MaxValue;

    public bool ValidAgeRange => MaxAge > MinAge;

    public string? SearchTerm { get; set; }

}
