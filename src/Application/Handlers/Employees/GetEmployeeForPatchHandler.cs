using Application.Queries.Employees;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Employees;

internal sealed class GetEmployeeForPatchHandler : IRequestHandler<GetEmployeeForPatchQuery, (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetEmployeeForPatchHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> Handle(GetEmployeeForPatchQuery request, CancellationToken cancellationToken)
    {
        var company = await _repository.Company.GetCompanyByIdAsync(request.CompanyId, request.CompanyTrackChanges);
        if (company is null)
            throw new CompanyNotFoundException(request.CompanyId);

        var employee = await _repository.Employee.GetEmployeeForCompanyAsync(request.CompanyId, request.EmployeeId, request.EmployeeTrackChanges);
        if (employee is null)
            throw new EmployeeNotFoundException(request.EmployeeId, request.CompanyId);

        var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employee);

        return (employeeToPatch, employee);
    }

}
