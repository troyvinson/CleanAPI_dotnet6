using Domain.Entities;
using MediatR;

namespace Application.Queries.Employees;

public sealed record GetEmployeeForPatchQuery(int CompanyId, int EmployeeId, bool CompanyTrackChanges, bool EmployeeTrackChanges) : IRequest<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)>;
