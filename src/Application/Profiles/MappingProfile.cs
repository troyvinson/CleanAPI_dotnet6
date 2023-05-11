using AutoMapper;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<UserForCreationDto, User>().ReverseMap();
        CreateMap<UserForUpdateDto, User>().ReverseMap();

        CreateMap<Tenant, TenantDto>().ReverseMap();
        CreateMap<TenantForCreationDto, Tenant>().ReverseMap();
        CreateMap<TenantForUpdateDto, Tenant>().ReverseMap();

        CreateMap<Member, MemberDto>()
            .ForMember(m => m.TenantName, opt => opt.MapFrom(x => x.Tenant!.Name))
            .ForMember(m => m.Username, opt => opt.MapFrom(u => u.User!.Username))
            .ForMember(m => m.FirstName, opt => opt.MapFrom(u => u.User!.GivenName))
            .ForMember(m => m.LastName, opt => opt.MapFrom(u => u.User!.Surname))
            .ForMember(m => m.Email, opt => opt.MapFrom(u => u.User!.Email))
            .ForMember(m => m.PhoneNumber, opt => opt.MapFrom(u => u.User!.PhoneNumber))
            .ReverseMap();
        CreateMap<MemberForCreationDto, Member>().ReverseMap();
        CreateMap<MemberForUpdateDto, Member>().ReverseMap();

        CreateMap<Role, RoleDto>().ReverseMap();
        CreateMap<RoleForCreationDto, Role>().ReverseMap();
        CreateMap<RoleForUpdateDto, Role>().ReverseMap();

        CreateMap<RoleType, RoleTypeDto>().ReverseMap();
        CreateMap<RoleTypeForCreationDto, RoleType>().ReverseMap();
        CreateMap<RoleTypeForUpdateDto, RoleType>().ReverseMap();



        CreateMap<Company, CompanyDto>()
            .ForMember(c => c.FullAddress,
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)))
            .ReverseMap();
        CreateMap<CompanyForCreationDto, Company>().ReverseMap();
        CreateMap<CompanyForUpdateDto, Company>().ReverseMap();
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<EmployeeForCreationDto, Employee>().ReverseMap();
        CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();

    }
}
