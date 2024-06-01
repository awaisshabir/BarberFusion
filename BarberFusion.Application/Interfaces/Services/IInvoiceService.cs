using BarberFusion.Domain.Entities;

namespace BarberFusion.Application.Interfaces.Services
{
    public interface IInvoiceService
    {
        Task<Invoice> GetByIdAsync(Guid id);
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task AddAsync(Invoice invoice);
        Task UpdateAsync(Invoice invoice);
        Task DeleteAsync(Guid id);
    }
}
