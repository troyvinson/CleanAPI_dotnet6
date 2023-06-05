using Domain.RequestFeatures;
using MediatR;

namespace Application.Features.Users.Queries;

public sealed record GetUsersQuery(UserParameters UserParameters, bool TrackChanges) : IRequest<IEnumerable<UserDto>>;
