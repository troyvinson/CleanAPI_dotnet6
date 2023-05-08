using Application.Commands.Companies;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Companies;

internal sealed class CreateCompanyCollectionHandler : IRequestHandler<CreateCompanyCollectionCommand, (IEnumerable<CompanyDto> companies, string ids)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateCompanyCollectionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<CompanyDto> companies, string ids)> Handle(CreateCompanyCollectionCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new CompanyCollectionBadRequest();

        var companyEntities = _mapper.Map<IEnumerable<Company>>(request.CompanyCollection);
        foreach (var company in companyEntities)
        {
            _repository.Company.CreateCompany(company);
        }

        await _repository.SaveAsync();

        var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
        var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));

        return (companies: companyCollectionToReturn, ids);

    }
}
