using MediatR;

namespace Application.Commands.CompanyCommands;

public record DeleteCompanyCommand(int Id, bool TrackChanges) : IRequest;
