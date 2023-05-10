using Application.Queries.Companies;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Companies;

internal sealed class GetCompanyForPatchHandler : IRequestHandler<GetCompanyForPatchQuery, (CompanyForUpdateDto companyToPatch, Company companyEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetCompanyForPatchHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(CompanyForUpdateDto companyToPatch, Company companyEntity)> Handle(GetCompanyForPatchQuery request, CancellationToken cancellationToken)
    {
        var company = await _repository.Company.GetCompanyByIdAsync(request.CompanyId, request.TrackChanges);
        if (company is null)
            throw new CompanyNotFoundException(request.CompanyId);

        var companyToPatch = _mapper.Map<CompanyForUpdateDto>(company);

        return (companyToPatch, company);
    }

}
