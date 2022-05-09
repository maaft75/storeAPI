using AutoMapper;
using store.Domain.DTOs;
using store.Domain.Models.v2;
using store.Repository.Repository.v2;

namespace store.Service.Service.v2
{
    public class UsersService
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepo;
        public UsersService(IMapper mapper, UserRepository userRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public async Task<Dictionary<string, object>> Registration(UserDto userDto)
        {
            Dictionary<string, object> result = new();
            try
            {
                User user = _mapper.Map<User>(userDto);
                await _userRepo.Create(user);
                result.Add("message", "User created successfully");
                result.Add("data", userDto);
                return result;
            }
            catch (Exception ex)
            {
                result.Add("error", ex.ToString());
                return result;
            }
        }
    }
}