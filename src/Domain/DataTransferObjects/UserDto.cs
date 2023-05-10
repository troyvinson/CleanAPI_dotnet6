namespace Domain.DataTransferObjects;

public record UserDto(int Id, string GivenName, string Surname, string Username, string Email, string PhoneNumber);
