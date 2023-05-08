using MediatR;

namespace Application.Commands.Companies;

public record DeleteCompanyCommand(int CompanyId, bool TrackChanges) : IRequest;
