using BarberFusion.Application.Interfaces.Repositories;
using BarberFusion.Domain.Entities;
using BarberFusion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BarberFusion.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BarberFusionContext _context;

        public CustomerRepository(BarberFusionContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _context.Customers
                .Include(c => c.Invoices)
                .Include(c => c.Appointments)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers
                .Include(c => c.Invoices)
                .Include(c => c.Appointments)
                .ToListAsync();
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
