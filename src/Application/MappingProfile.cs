using AutoMapper;

namespace Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserForRegistrationDto, User>();

        CreateMap<Tenant, TenantDto>().ReverseMap();
        CreateMap<TenantForCreationDto, Tenant>().ReverseMap();
        CreateMap<TenantForUpdateDto, Tenant>().ReverseMap();

        CreateMap<Member, MemberDto>()
            .ForMember(m => m.Tenant, opt => opt.MapFrom(x => x.Tenant))
            .ForMember(m => m.User, opt => opt.MapFrom(u => u.User)).ReverseMap();
        CreateMap<MemberForCreationDto, Member>().ReverseMap();
        CreateMap<MemberForUpdateDto, Member>().ReverseMap();

        CreateMap<MemberUserDto, User>().ReverseMap();
        CreateMap<MemberTenantDto, Tenant>().ReverseMap();


    }
}
