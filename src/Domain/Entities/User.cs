﻿using Domain.Interfaces;

namespace Domain.Entities;

public class User : ISoftDeletable
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public bool IsDeleted { get; set; }


    public ICollection<UserTenant> UserTenants { get; set; } = new List<UserTenant>();
}

