using MediatR;

namespace Application.Commands.Tenants;

public record DeleteTenantCommand(Guid TenantId, bool TrackChanges) : IRequest;
