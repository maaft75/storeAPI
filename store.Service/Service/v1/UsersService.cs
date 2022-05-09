using AutoMapper;
using store.Domain.DTOs;
using store.Domain.Models.v1;
using store.Domain.Interfaces;
using store.Repository.Repository;

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
                    await _unitOfWork.userRepo.Create(user);
                    if(await _unitOfWork.Save())
                    {
                        result.Add("message", "User created successfully");
                        result.Add("data", userDto);
                        return result;
                    }
                    else
                    {
                        result.Add("message", "Registration failed.");
                        return result;
                    }
                }
                else
                {
                    result.Add("message", "This email address is already in use.");
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Add("error", ex.ToString());
                return result;
            }
        }

        public async Task<Dictionary<string, object>> GetUser(int Id)
        {
            Dictionary<string, object> result = new();
            User user = await _unitOfWork.userRepo.FindByCondition(x => x.Id == Id);
            result.Add("data", user);
            result.Add("message", "success");
            return result;
        }

        // public async Task<List<User>> GetUser(int Id)
        // {
        //     return await _unitOfWork.userRepo.FindByAll();
        // }
    }
}