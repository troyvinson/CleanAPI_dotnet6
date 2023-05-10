﻿namespace Domain.DataTransferObjects;

public abstract record MemberForManipulationDto
{
    public string Name { get; init; }

    public int Age { get; init; }

    public string Position { get; init; }
}
