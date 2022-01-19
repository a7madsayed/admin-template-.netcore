namespace CompanyName.Identity.Data
{
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.RoleClaim, Core.Models.RoleClaim>().ReverseMap();
            CreateMap<Entities.Role, Core.Models.Role>().ReverseMap();
            CreateMap<Entities.UserClaim, Core.Models.UserClaim>().ReverseMap();
            CreateMap<Entities.UserLogin, Core.Models.UserLogin>().ReverseMap();
            CreateMap<Entities.UserRole, Core.Models.UserRole>().ReverseMap();
            CreateMap<Entities.User, Core.Models.User>().ReverseMap();
            CreateMap<Entities.UserToken, Core.Models.UserToken>().ReverseMap();
        }
    }
}
