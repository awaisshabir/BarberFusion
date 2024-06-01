using BarberFusion.Application.Interfaces.Repositories;
using BarberFusion.Application.Interfaces.Services;
using BarberFusion.Domain.Entities;

namespace BarberFusion.Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Service> GetByIdAsync(Guid id)
        {
            try
            {
                return await _serviceRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException($"Error getting service by id: {id}", ex);
            }
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            try
            {
                return await _serviceRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error getting all services", ex);
            }
        }

        public async Task AddAsync(Service service)
        {
            try
            {
                await _serviceRepository.AddAsync(service);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error adding service", ex);
            }
        }

        public async Task UpdateAsync(Service service)
        {
            try
            {
                await _serviceRepository.UpdateAsync(service);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error updating service", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _serviceRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException($"Error deleting service with id: {id}", ex);
            }
        }
    }
}
