using AutoMapper;

namespace Application.Profiles;

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
            .ForMember(m => m.User, opt => opt.MapFrom(u => u.User));
        CreateMap<MemberForCreationDto, Member>().ReverseMap();
        CreateMap<MemberForUpdateDto, Member>().ReverseMap();

    }
}
