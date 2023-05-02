using Application.Commands.EmployeeCommands;
using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
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
        var companyEntity = await _repository.Company.GetCompanyByIdAsync(request.companyId, request.companyTrackChanges);
        if (companyEntity is null)
            throw new CompanyNotFoundException(request.companyId);

        var employeeEntity = await _repository.Employee.GetEmployeeForCompanyAsync(request.companyId, request.employeeyId, request.employeeTrackChanges);
        if (employeeEntity is null)
            throw new EmployeeNotFoundException(request.employeeyId, request.companyId);

        _mapper.Map(request.Employee, employeeEntity);
        await _repository.SaveAsync();

        return Unit.Value;
    }

}
