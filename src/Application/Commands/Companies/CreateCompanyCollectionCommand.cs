using MediatR;

namespace Application.Commands.CompanyCommands;

public sealed record CreateCompanyCollectionCommand(IEnumerable<CompanyForCreationDto> companyCollection) : IRequest<(IEnumerable<CompanyDto> companies, string ids)>;
