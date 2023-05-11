using Application.Queries.Members;
using AutoMapper;
using Domain.Exceptions;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Handlers.Members;

internal sealed class GetMembersByIdsHandler : IRequestHandler<GetMembersByIdsQuery, (IEnumerable<MemberDto> members, MetaData metaData)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMembersByIdsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<MemberDto> members, MetaData metaData)> Handle(GetMembersByIdsQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new IdParametersBadRequestException();

        _ = await _repository.Tenant.GetTenantByIdAsync(request.TenantId, request.TrackChanges)
            ?? throw new NotFoundException($"Tenant ID: {request.TenantId} was not found.");

        var ids = request.MemberIds.Split(',').Select(id => int.Parse(id)).ToList();

        var memberEntities = await _repository.Member.GetMembersByIdsAsync(request.TenantId, ids, request.MemberParameters, request.TrackChanges);

        if (ids.Count != memberEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var MembersToReturn = _mapper.Map<IEnumerable<MemberDto>>(memberEntities);

        return (members: MembersToReturn, metaData: memberEntities.MetaData);

    }
}
