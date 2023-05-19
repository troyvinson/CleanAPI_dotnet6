using MediatR;

namespace Application.Features.Users.Queries;

public sealed record GetUsersByIdsQuery(string UserIds, bool TrackChanges) : IRequest<IEnumerable<UserDto>>;
