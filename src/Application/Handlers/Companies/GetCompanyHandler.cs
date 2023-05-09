using Application.Queries.Companies;
using Application.Queries.Tenants;
using Application.Queries.Users;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Companies;

internal sealed class GetCompanyHandler : IRequestHandler<GetCompanyQuery, CompanyDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetCompanyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        var company = await _repository.Company.GetCompanyByIdAsync(request.Id, request.TrackChanges);
        if (company is null)
            throw new CompanyNotFoundException(request.Id);

        var companyDto = _mapper.Map<CompanyDto>(company);

        return companyDto;
    }
}
