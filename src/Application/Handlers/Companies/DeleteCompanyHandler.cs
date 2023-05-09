﻿using Application.Notifications;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Companies;

internal sealed class DeleteCompanyHandler : INotificationHandler<CompanyDeletedNotification>
{
    private readonly IRepositoryManager _repository;

    public DeleteCompanyHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(CompanyDeletedNotification notification, CancellationToken cancellationToken)
    {
        var company = await _repository.Company.GetCompanyByIdAsync(notification.CompanyId, notification.TrackChanges) 
            ?? throw new CompanyNotFoundException(notification.CompanyId);

        _repository.Company.DeleteCompany(company);
        await _repository.SaveAsync();
    }
}
