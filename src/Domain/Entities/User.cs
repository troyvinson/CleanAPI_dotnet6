﻿using Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class User : BaseEntity, ISoftDeletable
{
    [Column("UserId")]
    public int Id { get; set; }
    public string GivenName { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }


    public bool IsDeleted { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<Member> Memberships { get; set; }
}

