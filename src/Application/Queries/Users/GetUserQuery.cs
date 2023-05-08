using MediatR;

namespace Application.Queries.Users;

public sealed record GetUserQuery(int UserId, bool TrackChanges) : IRequest<UserDto>;
