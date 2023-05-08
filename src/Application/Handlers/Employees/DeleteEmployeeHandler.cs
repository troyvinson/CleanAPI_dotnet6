using Application.Commands.Employees;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Employees;

internal sealed class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteEmployeeHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _repository.Employee.GetEmployeeForCompanyAsync(request.companyId, request.employeeId, request.TrackChanges);
        if (employee is null)
            throw new EmployeeNotFoundException(request.employeeId, request.companyId);

        _repository.Employee.DeleteEmployee(employee);
        await _repository.SaveAsync();
    }
}
