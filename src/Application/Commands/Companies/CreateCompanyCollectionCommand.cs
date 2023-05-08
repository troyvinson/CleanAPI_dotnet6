using MediatR;

namespace Application.Commands.Companies;

public sealed record CreateCompanyCollectionCommand(IEnumerable<CompanyForCreationDto> companyCollection) : IRequest<(IEnumerable<CompanyDto> companies, string ids)>;
