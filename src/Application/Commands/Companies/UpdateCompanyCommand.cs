using MediatR;

namespace Application.Commands.CompanyCommands;

public sealed record UpdateCompanyCommand
    (int Id, CompanyForUpdateDto Company, bool TrackChanges) : IRequest<Unit>;
