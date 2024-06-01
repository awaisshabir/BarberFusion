using BarberFusion.Application.Interfaces.Repositories;
using BarberFusion.Domain.Entities;
using BarberFusion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BarberFusion.Infrastructure.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly BarberFusionContext _context;

        public ShopRepository(BarberFusionContext context)
        {
            _context = context;
        }

        public async Task<Shop> GetByIdAsync(Guid id)
        {
            return await _context.Shops.FindAsync(id);
        }

        public async Task<IEnumerable<Shop>> GetAllAsync()
        {
            return await _context.Shops
            .Include(s => s.Users)
            .Include(s => s.Services)
            .Include(s => s.Customers)
            .Include(s => s.Appointments)
            .Include(s => s.Invoices)
            .ToListAsync();
        }

        public async Task AddAsync(Shop shop)
        {
            await _context.Shops.AddAsync(shop);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shop shop)
        {
            _context.Entry(shop).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var shop = await _context.Shops.FindAsync(id);
            if (shop != null)
            {
                _context.Shops.Remove(shop);
                await _context.SaveChangesAsync();
            }
        }
    }
}
