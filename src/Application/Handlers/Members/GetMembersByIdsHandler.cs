using Application.Queries.Members;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Members;

internal sealed class GetMembersByIdsHandler : IRequestHandler<GetMembersByIdsQuery, IEnumerable<MemberDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMembersByIdsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MemberDto>> Handle(GetMembersByIdsQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new IdParametersBadRequestException();

        var ids = request.MemberIds.Split(',').Select(id => int.Parse(id)).ToList();

        var memberEntities = await _repository.Member.GetMembersByIdsAsync(request.TenantId, ids, request.MemberParameters, request.TrackChanges);

        var MembersToReturn = _mapper.Map<IEnumerable<MemberDto>>(memberEntities);

        return MembersToReturn;
    }
}
