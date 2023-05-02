using MediatR;

namespace Application.Commands.CompanyCommands;

public sealed record CreateCompanyCommand(CompanyForCreationDto Company) : IRequest<CompanyDto>;
