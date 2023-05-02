using Application.Queries.EmployeeQueries;
using AutoMapper;
using Domain.Exceptions;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Handlers.Employees;

internal sealed class GetEmployeesForCompanyHandler : IRequestHandler<GetEmployeesForCompanyQuery, (IEnumerable<EmployeeDto> employees, MetaData metaData)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetEmployeesForCompanyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<EmployeeDto> employees, MetaData metaData)> Handle(GetEmployeesForCompanyQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new IdParametersBadRequestException();

        if (!request.EmployeeParameters.ValidAgeRange) 
            throw new MaxAgeRangeBadRequestException();

        var company = await _repository.Company.GetCompanyByIdAsync(request.CompanyId, request.TrackChanges);
        if (company is null)
            throw new CompanyNotFoundException(request.CompanyId);

        var employeesWithMetaData = await _repository.Employee.GetEmployeesForCompanyAsync(request.CompanyId, request.EmployeeParameters, request.TrackChanges);

        var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);

        return (employees: employeesDto, metaData: employeesWithMetaData.MetaData);
    }
}
