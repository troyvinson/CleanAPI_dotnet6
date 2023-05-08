﻿namespace Domain.Exceptions;

public sealed class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(int companyId)
        : base($"The company with id: {companyId} doesn't exist in the database.")
    {
    }
}