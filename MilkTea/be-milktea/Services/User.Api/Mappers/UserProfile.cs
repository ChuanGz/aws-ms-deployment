using AutoMapper;
using User.Api.Models.Commands;
using User.Api.Models.Queries;

namespace User.Api.Mappers;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<Data.Entities.User, UserGetOne>().ReverseMap();
        CreateMap<Data.Entities.User, UserCreate>().ReverseMap();
        CreateMap<Data.Entities.User, UserUpdate>().ReverseMap();

        CreateMap<Data.Entities.UserGroup, GroupGetOne>().ReverseMap();
        CreateMap<Data.Entities.UserGroup, GroupCreate>().ReverseMap();
        CreateMap<Data.Entities.UserGroup, GroupGetOne>().ReverseMap();
    }
}
