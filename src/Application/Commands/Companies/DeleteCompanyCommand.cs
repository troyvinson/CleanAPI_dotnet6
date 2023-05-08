using MediatR;

namespace Application.Commands.Companies;

public record DeleteCompanyCommand(int Id, bool TrackChanges) : IRequest;
