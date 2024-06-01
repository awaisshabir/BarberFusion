using BarberFusion.Application.Interfaces.Repositories;
using BarberFusion.Application.Interfaces.Services;
using BarberFusion.Domain.Entities;

namespace BarberFusion.Application.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<Shop> GetByIdAsync(Guid id)
        {
            try
            {
                return await _shopRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException($"Error getting shop by id: {id}", ex);
            }
        }

        public async Task<IEnumerable<Shop>> GetAllAsync()
        {
            try
            {
                return await _shopRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error getting all shops", ex);
            }
        }

        public async Task AddAsync(Shop shop)
        {
            try
            {
                await _shopRepository.AddAsync(shop);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error adding shop", ex);
            }
        }

        public async Task UpdateAsync(Shop shop)
        {
            try
            {
                await _shopRepository.UpdateAsync(shop);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error updating shop", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _shopRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException($"Error deleting shop with id: {id}", ex);
            }
        }
    }
}
