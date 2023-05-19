using MediatR;

namespace Application.Features.Users.Queries;

public sealed record GetUserQuery(Guid UserId, bool TrackChanges) : IRequest<UserDto>;
