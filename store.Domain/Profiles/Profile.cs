using store.Domain.DTOs;
using userv1 = store.Domain.Models.v1;
using userv2 = store.Domain.Models.v2;

namespace store.Domain.Profiles
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<UserDto, userv1.User>();
            //CreateMap<User, UserDto>();

            //v2
            CreateMap<UserDto, userv2.User>();
        }
    }
}