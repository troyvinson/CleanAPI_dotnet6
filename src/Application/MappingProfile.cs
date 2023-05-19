using AutoMapper;

namespace Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserForRegistrationDto, User>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<User, MemberUserDto>().ReverseMap();

        CreateMap<Tenant, TenantDto>().ReverseMap();
        CreateMap<TenantForCreationDto, Tenant>().ReverseMap();
        CreateMap<TenantForUpdateDto, Tenant>().ReverseMap();
        CreateMap<Tenant, MemberTenantDto>().ReverseMap();

        CreateMap<Member, MemberDto>()
            .ForMember(m => m.Tenant, opt => opt.MapFrom(x => x.Tenant))
            .ForMember(m => m.User, opt => opt.MapFrom(u => u.User));
        CreateMap<MemberForCreationDto, Member>().ReverseMap();
        CreateMap<MemberForUpdateDto, Member>().ReverseMap();



    }
}
