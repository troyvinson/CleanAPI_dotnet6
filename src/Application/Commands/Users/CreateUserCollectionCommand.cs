using MediatR;

namespace Application.Commands.Users;

public sealed record CreateUserCollectionCommand(IEnumerable<UserForCreationDto> UserCollection) : IRequest<(IEnumerable<UserDto> users, string ids)>;
