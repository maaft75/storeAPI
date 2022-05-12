using AutoMapper;
using store.Domain.DTOs;
using store.Domain.Interfaces;
using store.Domain.Models.v1;

namespace store.Service.Service.v1
{
    public class StoreService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public StoreService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Dictionary<string, object>> CreateStore(CreateStoreDto createStoreDto)
        {
            Dictionary<string, object> response = new();
            try
            {
                Store createStore = _mapper.Map<Store>(createStoreDto);
                User getStoreOwner = await _unitOfWork.userRepo
                                .FindByCondition(x => x.Id == createStoreDto.StoreOwnerId);
                if(getStoreOwner != null){
                    createStore.StoreOwner = getStoreOwner;
                    await _unitOfWork.storeRepo.Create(createStore);
                    await _unitOfWork.Save();
                }
                else{
                    response.Add("error", "No store owner found.");
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Add("error", ex.ToString());
                return response;
            }
        }

        public async Task<Dictionary<string, object>> GetStoreByUser(int Id)
        {
            Dictionary<string, object> response = new();
            try
            {
                Store storesByOwner = await _unitOfWork.storeRepo
                                .FindByCondition(x => x.Id == Id);
                if(storesByOwner != null){
                    response.Add("data", storesByOwner);
                    response.Add("message", "Stores fetched successfully.");
                }
                else{
                    response.Add("error", "No stores for this user found.");
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Add("error", ex.ToString());
                return response;
            }
        }
        
    }
}