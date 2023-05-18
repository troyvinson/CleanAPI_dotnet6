using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Commands.Members;

internal sealed class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateMemberCommandHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
    {
        _ = await _repository.Tenant.GetTenantByIdAsync(request.TenantId, request.TenantTrackChanges)
            ?? throw new NotFoundException($"Tenant ID: {request.TenantId} was not found.");

        var memberEntity = await _repository.Member.GetMemberForTenantAsync(request.TenantId, request.MemberId, request.MemberTrackChanges)
            ?? throw new NotFoundException($"Member ID: {request.MemberId} not found for Tenant ID: {request.TenantId}.");

        _mapper.Map(request.Member, memberEntity);
        await _repository.SaveAsync();

        return Unit.Value;
    }

}
