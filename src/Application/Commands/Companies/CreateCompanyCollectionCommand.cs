using MediatR;

namespace Application.Commands.Companies;

public sealed record CreateCompanyCollectionCommand(IEnumerable<CompanyForCreationDto> CompanyCollection) : IRequest<(IEnumerable<CompanyDto> companies, string ids)>;
