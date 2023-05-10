using Application.Commands.Companies;
using AutoMapper;
using MediatR;

namespace Application.Handlers.Companies;

internal sealed class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CompanyDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateCompanyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var companyEntity = _mapper.Map<Company>(request.Company);

        _repository.Company.CreateCompany(companyEntity);
        await _repository.SaveAsync();

        var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);

        return companyToReturn;
    }
}
