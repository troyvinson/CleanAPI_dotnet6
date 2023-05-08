using Application.Commands.Employees;
using Application.Commands.Users;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Employees;

internal sealed class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateEmployeeHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        _ = await _repository.Company.GetCompanyByIdAsync(request.CompanyId, request.CompanyTrackChanges)
            ?? throw new CompanyNotFoundException(request.CompanyId);

        var employeeEntity = await _repository.Employee.GetEmployeeForCompanyAsync(request.CompanyId, request.EmployeeyId, request.EmployeeTrackChanges) 
            ?? throw new EmployeeNotFoundException(request.EmployeeyId, request.CompanyId);

        _mapper.Map(request.Employee, employeeEntity);
        await _repository.SaveAsync();

        return Unit.Value;
    }

}
