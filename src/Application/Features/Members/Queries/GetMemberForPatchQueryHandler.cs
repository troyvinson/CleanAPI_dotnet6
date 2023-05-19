using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Members.Queries;

internal sealed class GetMemberForPatchQueryHandler : IRequestHandler<GetMemberForPatchQuery, (MemberForUpdateDto memberToPatch, Member memberEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMemberForPatchQueryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(MemberForUpdateDto memberToPatch, Member memberEntity)> Handle(GetMemberForPatchQuery request, CancellationToken cancellationToken)
    {
        _ = await _repository.Tenant.GetTenantByIdAsync(request.TenantId, request.TenantTrackChanges)
            ?? throw new NotFoundException($"Tenant ID: {request.TenantId} was not found.");

        var member = await _repository.Member.GetMemberForTenantAsync(request.TenantId, request.MemberId, request.MemberTrackChanges)
            ?? throw new NotFoundException($"Member ID: {request.MemberId} not found for Tenant ID: {request.TenantId}.");

        var memberToPatch = _mapper.Map<MemberForUpdateDto>(member);

        return (memberToPatch, member);
    }

}
