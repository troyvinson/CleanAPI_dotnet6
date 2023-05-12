using MediatR;

namespace Application.Commands.Companies;

public sealed record UpdateCompanyCommand (int CompanyId, CompanyForUpdateDto Company, bool TrackChanges) 
    : IRequest<Unit>;
