using BarberFusion.Application.Interfaces.Repositories;
using BarberFusion.Application.Interfaces.Services;
using BarberFusion.Domain.Entities;

namespace BarberFusion.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Invoice> GetByIdAsync(Guid id)
        {
            try
            {
                return await _invoiceRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException($"Error getting invoice by id: {id}", ex);
            }
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            try
            {
                return await _invoiceRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error getting all invoices", ex);
            }
        }

        public async Task AddAsync(Invoice invoice)
        {
            try
            {
                await _invoiceRepository.AddAsync(invoice);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error adding invoice", ex);
            }
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            try
            {
                await _invoiceRepository.UpdateAsync(invoice);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error updating invoice", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _invoiceRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException($"Error deleting invoice with id: {id}", ex);
            }
        }
    }
}
