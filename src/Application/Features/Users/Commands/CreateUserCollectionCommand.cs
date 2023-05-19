using MediatR;

namespace Application.Features.Users.Commands;

public sealed record CreateUserCollectionCommand(IEnumerable<UserForCreationDto> UserCollection) : IRequest<(IEnumerable<UserDto> users, string ids)>;
