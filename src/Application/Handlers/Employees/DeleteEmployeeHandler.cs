using Application.Commands.Employees;
using Application.Commands.Users;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Employees;

internal sealed class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteEmployeeHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _repository.Employee.GetEmployeeForCompanyAsync(request.CompanyId, request.EmployeeId, request.TrackChanges) 
            ?? throw new EmployeeNotFoundException(request.EmployeeId, request.CompanyId);

        _repository.Employee.DeleteEmployee(employee);
        await _repository.SaveAsync();
    }
}
