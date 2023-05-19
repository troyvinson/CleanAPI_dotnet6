using MediatR;

namespace Application.Features.Users.Queries;

public sealed record GetUserForPatchQuery(Guid UserId, bool TrackChanges) : IRequest<(UserForUpdateDto userToPatch, User userEntity)>;
