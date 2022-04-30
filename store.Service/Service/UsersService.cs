using store.Domain.Models;
using store.Domain.Interfaces;

namespace store.Service.Service
{
    public class UsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Registration(User user)
        {
            _unitOfWork.userRepo.Create(user);
        }

        public async Task<User> GetUser(int Id)
        {
            return await _unitOfWork.userRepo.FindByCondition(x => x.Id == Id);
        }
    }
}