namespace Domain.DataTransferObjects;

public record CompanyForUpdateDto : CompanyForManipulationDto
{
    public IEnumerable<EmployeeForCreationDto>? Employees { get; init; }
}
