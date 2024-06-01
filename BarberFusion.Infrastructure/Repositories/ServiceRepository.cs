using BarberFusion.Application.Interfaces.Repositories;
using BarberFusion.Domain.Entities;
using BarberFusion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BarberFusion.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly BarberFusionContext _context;

        public ServiceRepository(BarberFusionContext context)
        {
            _context = context;
        }

        public async Task<Service> GetByIdAsync(Guid id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task AddAsync(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
        }
    }
}
