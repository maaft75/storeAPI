using AutoMapper;
using store.Domain.DTOs;
using store.Domain.Requests;
using store.Domain.Models.v1;
using store.Domain.Interfaces;

namespace store.Service.Service.v1
{
    public class UsersService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UsersService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Dictionary<string, object>> Registration(UserDto userDto)
        {
            Dictionary<string, object> result = new();
            try
            {
                if (await _unitOfWork.userRepo.CheckIfEmailExists(userDto.Email_Address) == false)
                {
                    User user = _mapper.Map<User>(userDto);
                    user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
                    await _unitOfWork.userRepo.Create(user);
                    await _unitOfWork.Save();
                    result.Add("message", "User created successfully");
                    result.Add("data", userDto);
                }
                else
                {
                    result.Add("message", "This email address is already in use.");
                }
                return result;
            }
            catch (Exception ex)
            {
                result.Add("error", ex.ToString());
                return result;
            }
        }

        public async Task<Dictionary<string, object>> Login(Login login)
        {
            Dictionary<string, object> result = new();
            try
            {
                User user = await _unitOfWork.userRepo
                                .FindByCondition(x => x.Email_Address == login.Email_Address);
                bool verifyPassword = BCrypt.Net.BCrypt.Verify(login.Password, user.Password);
                if(user != null && verifyPassword)
                {
                    GetUserDto getUserDto = _mapper.Map<GetUserDto>(user);
                    result.Add("data", getUserDto);
                    result.Add("message", "success");
                }
                else
                {
                    result.Add("error", "Invalid credentials.");
                }
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