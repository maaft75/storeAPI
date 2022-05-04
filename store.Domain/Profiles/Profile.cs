using store.Domain.DTOs;
using store.Domain.Models;

namespace store.Domain.Profiles
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<UserDto, User>();
            //CreateMap<User, UserDto>();
        }
    }
}