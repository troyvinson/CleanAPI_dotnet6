using Application.Queries.CompanyQueries;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Companies;

internal sealed class GetCompaniesByIdsHandler : IRequestHandler<GetCompaniesByIdsQuery, IEnumerable<CompanyDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetCompaniesByIdsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CompanyDto>> Handle(GetCompaniesByIdsQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new IdParametersBadRequestException();

        var ids = request.ids.Split(',').Select(id => int.Parse(id)).ToList();

        var companyEntities = await _repository.Company.GetCompaniesByIdsAsync(ids, request.TrackChanges);
        if (ids.Count() != companyEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);

        return companiesToReturn;
    }
}
