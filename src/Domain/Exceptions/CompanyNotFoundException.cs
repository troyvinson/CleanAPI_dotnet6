﻿namespace Domain.Exceptions;

public sealed class CompanyNotFoundException : NotFoundException
{
    public CompanyNotFoundException(int companyId)
        : base($"The company with id: {companyId} doesn't exist in the database.")
    {
    }
}
