namespace Domain.DataTransferObjects;

public abstract record UserForManipulationDto
{
    public int Id { get; set; }
    public string GivenName { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
