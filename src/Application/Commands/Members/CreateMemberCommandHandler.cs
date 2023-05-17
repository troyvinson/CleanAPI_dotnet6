using Domain.DataTransferObjects;
using AutoMapper;
using MediatR;

namespace Application.Commands.Members;

internal sealed class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, MemberDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateMemberCommandHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MemberDto> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var memberEntity = _mapper.Map<Member>(request.Member);

        _repository.Member.CreateMemberForTenant(request.TenantId, memberEntity);
        await _repository.SaveAsync();

        var memberToReturn = _mapper.Map<MemberDto>(memberEntity);

        return memberToReturn;
    }
}
