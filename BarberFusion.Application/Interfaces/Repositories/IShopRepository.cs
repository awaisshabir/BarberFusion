using BarberFusion.Domain.Entities;

namespace BarberFusion.Application.Interfaces.Repositories
{
    public interface IShopRepository
    {
        Task<Shop> GetByIdAsync(Guid id);
        Task<IEnumerable<Shop>> GetAllAsync();
        Task AddAsync(Shop shop);
        Task UpdateAsync(Shop shop);
        Task DeleteAsync(Guid id);
    }
}
