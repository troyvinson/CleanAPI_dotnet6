using Application.Queries.Members;
using AutoMapper;
using Domain.Exceptions;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Handlers.Members;

internal sealed class GetMembersForTenantPagedHandler : IRequestHandler<GetMembersForTenantPagedQuery, (IEnumerable<MemberDto> members, PagingMetaData metaData)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMembersForTenantPagedHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<MemberDto> members, PagingMetaData metaData)> Handle(GetMembersForTenantPagedQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new IdParametersBadRequestException();

        _ = await _repository.Tenant.GetTenantByIdAsync(request.TenantId, request.TrackChanges)
            ?? throw new NotFoundException($"Tenant ID: {request.TenantId} was not found.");

        var membersWithMetaData = await _repository.Member.GetMembersForTenantPagedAsync(request.TenantId, request.MemberParameters, request.TrackChanges);

        var membersDto = _mapper.Map<IEnumerable<MemberDto>>(membersWithMetaData);

        return (members: membersDto, metaData: membersWithMetaData.MetaData);
    }
}
