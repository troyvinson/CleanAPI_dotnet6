using Application.Queries.Members;
using AutoMapper;
using Domain.Exceptions;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Handlers.Members;

internal sealed class GetMembersForTenantHandler : IRequestHandler<GetMembersForTenantQuery, (IEnumerable<MemberDto> members, MetaData metaData)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMembersForTenantHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<MemberDto> members, MetaData metaData)> Handle(GetMembersForTenantQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new IdParametersBadRequestException();

        _ = await _repository.Tenant.GetTenantByIdAsync(request.TenantId, request.TrackChanges)
            ?? throw new NotFoundException($"Tenant ID: {request.TenantId} was not found.");

        var membersWithMetaData = await _repository.Member.GetMembersForTenantAsync(request.TenantId, request.MemberParameters, request.TrackChanges);

        var membersDto = _mapper.Map<IEnumerable<MemberDto>>(membersWithMetaData);

        return (members: membersDto, metaData: membersWithMetaData.MetaData);
    }
}
