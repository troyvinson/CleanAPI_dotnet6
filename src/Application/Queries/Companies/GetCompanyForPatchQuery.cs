using Domain.Entities;
using MediatR;

namespace Application.Queries.Companies;

public sealed record GetCompanyForPatchQuery(int CompanyId, bool TrackChanges) : IRequest<(CompanyForUpdateDto companyToPatch, Company companyEntity)>;
