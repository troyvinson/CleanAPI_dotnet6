using Application.Commands.Companies;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Companies;

internal sealed class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateCompanyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var companyEntity = await _repository.Company.GetCompanyByIdAsync(request.CompanyId, request.TrackChanges) 
            ?? throw new CompanyNotFoundException(request.CompanyId);

        _mapper.Map(request.Company, companyEntity);
        await _repository.SaveAsync();

        return Unit.Value;
    }

}
