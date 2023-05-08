using Application.Commands.Employees;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Employees;

internal sealed class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateEmployeeHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employeeEntity = _mapper.Map<Employee>(request.Employee);

        _repository.Employee.CreateEmployeeForCompany(request.companyId, employeeEntity);
        await _repository.SaveAsync();

        var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

        return employeeToReturn;
    }
}
