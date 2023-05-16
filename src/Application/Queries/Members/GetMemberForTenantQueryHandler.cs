using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Queries.Members;

internal sealed class GetMemberForTenantQueryHandler : IRequestHandler<GetMemberForTenantQuery, MemberDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMemberForTenantQueryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MemberDto> Handle(GetMemberForTenantQuery request, CancellationToken cancellationToken)
    {
        var member = await _repository.Member.GetMemberForTenantAsync(request.TenantId, request.MemberId, request.TrackChanges)
            ?? throw new NotFoundException($"Member ID: {request.MemberId} not found for Tenant ID: {request.TenantId}");

        var memberDto = _mapper.Map<MemberDto>(member);

        return memberDto;
    }

}
