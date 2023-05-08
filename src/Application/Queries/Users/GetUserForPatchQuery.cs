using Domain.Entities;
using MediatR;

namespace Application.Queries.Users;

public sealed record GetUserForPatchQuery(int UserId, bool TrackChanges) : IRequest<(UserForUpdateDto userToPatch, User userEntity)>;
