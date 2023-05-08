using MediatR;

namespace Application.Queries.Users;

public sealed record GetUsersByIdsQuery(string UserIds, bool TrackChanges) : IRequest<IEnumerable<UserDto>>;
