using AutoMapper;
using Domain.Exceptions;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Queries.Members;

internal sealed class GetMembersForTenantQueryHandler : IRequestHandler<GetMembersForTenantQuery, IEnumerable<MemberDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMembersForTenantQueryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MemberDto>> Handle(GetMembersForTenantQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new IdParametersBadRequestException();

        _ = await _repository.Tenant.GetTenantByIdAsync(request.TenantId, request.TrackChanges)
            ?? throw new NotFoundException($"Tenant ID: {request.TenantId} was not found.");

        var membersEntities = await _repository.Member.GetMembersForTenantAsync(request.TenantId, request.MemberParameters, request.TrackChanges);

        var membersDto = _mapper.Map<IEnumerable<MemberDto>>(membersEntities);

        return membersDto;
    }
}
