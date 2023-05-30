using MediatR;

namespace Application.Features.Users.Queries;

public sealed record GetUserQuery(string UserId, bool TrackChanges) : IRequest<UserDto>;
