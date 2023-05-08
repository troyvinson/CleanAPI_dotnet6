using MediatR;

namespace Application.Queries.Users;

public sealed record GetUsersQuery(bool TrackChanges) : IRequest<IEnumerable<UserDto>>;
