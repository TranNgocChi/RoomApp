using AutoMapper;
using UserService.Database;

namespace UserService.API;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<UserCreationModel, User>();
        CreateMap<User, UserCreationModel>();
        CreateMap<User, UserModel>();
        CreateMap<UserModel, User>();
    }
}
