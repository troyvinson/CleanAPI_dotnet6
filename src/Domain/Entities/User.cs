﻿namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string? GivenName { get; set; }
    public string? Surname { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
}
