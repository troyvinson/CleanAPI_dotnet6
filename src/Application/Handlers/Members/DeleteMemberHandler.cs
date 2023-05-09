using Application.Commands.Members;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Members;

internal sealed class DeleteMemberHandler : IRequestHandler<DeleteMemberCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteMemberHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await _repository.Member.GetMemberForTenantAsync(request.TenantId, request.MemberId, request.TrackChanges) 
            ?? throw new NotFoundException($"Member ID: {request.MemberId} not found for Tenant ID: {request.TenantId}");

        _repository.Member.DeleteMember(member);
        await _repository.SaveAsync();
    }
}
