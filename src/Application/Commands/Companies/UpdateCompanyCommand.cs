using MediatR;

namespace Application.Commands.Companies;

public sealed record UpdateCompanyCommand
    (int Id, CompanyForUpdateDto Company, bool TrackChanges) : IRequest<Unit>;
