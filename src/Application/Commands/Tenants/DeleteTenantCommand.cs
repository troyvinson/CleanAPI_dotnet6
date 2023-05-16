using MediatR;

namespace Application.Commands.Tenants;

public record DeleteTenantCommand(string TenantId, bool TrackChanges) : IRequest;
