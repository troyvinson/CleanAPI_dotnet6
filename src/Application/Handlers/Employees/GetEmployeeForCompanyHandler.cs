using Application.Queries.Employees;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Employees;

internal sealed class GetEmployeeForCompanyHandler : IRequestHandler<GetEmployeeForCompanyQuery, EmployeeDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetEmployeeForCompanyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeDto> Handle(GetEmployeeForCompanyQuery request, CancellationToken cancellationToken)
    {
        var employee = await _repository.Employee.GetEmployeeForCompanyAsync(request.CompanyId, request.EmployeeId, request.TrackChanges)
            ?? throw new EmployeeNotFoundException(request.EmployeeId, request.CompanyId);

        var employeeDto = _mapper.Map<EmployeeDto>(employee);

        return employeeDto;
    }

}
