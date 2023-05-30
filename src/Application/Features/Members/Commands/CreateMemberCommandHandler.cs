using AutoMapper;
using MediatR;

namespace Application.Features.Members.Commands;

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

        _repository.Member.CreateMember(memberEntity);
        await _repository.SaveAsync();

        var memberToReturn = _mapper.Map<MemberDto>(memberEntity);

        return memberToReturn;
    }
}
