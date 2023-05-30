using Domain.RequestFeatures;
using MediatR;

namespace Application.Features.Users.Queries;

public sealed record GetUsersByIdsQuery(string UserIds, UserParameters UserParameters, bool TrackChanges) : IRequest<IEnumerable<UserDto>>;
