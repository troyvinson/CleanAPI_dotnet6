using MediatR;

namespace Application.Features.Users.Queries;

public sealed record GetUsersQuery(bool TrackChanges) : IRequest<IEnumerable<UserDto>>;
