using MediatR;

namespace Application.Features.Tenants.Commands;

public record DeleteTenantCommand(Guid TenantId, bool TrackChanges) : IRequest;
