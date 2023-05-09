using MediatR;

namespace Application.Commands.Tenants;

public record DeleteTenantCommand(int TenantId, bool TrackChanges) : IRequest;
