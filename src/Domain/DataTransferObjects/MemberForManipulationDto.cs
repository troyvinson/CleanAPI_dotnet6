﻿namespace Domain.DataTransferObjects;

public abstract record MemberForManipulationDto
{
    public string? Position { get; set; }
    public DateTime DateJoined { get; set; }
    public Guid UserId { get; set; }

}
