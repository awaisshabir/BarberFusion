using BarberFusion.Application.Exceptions;
using BarberFusion.Application.Interfaces.Repositories;
using BarberFusion.Application.Interfaces.Services;
using BarberFusion.Domain.Entities;

namespace BarberFusion.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            try
            {
                return await _customerRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException($"Error getting customer by id: {id}", ex);
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            try
            {
                return await _customerRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error getting all customers", ex);
            }
        }

        public async Task AddAsync(Customer customer)
        {
            try
            {
                var existingCustomer = await _customerRepository.GetByIdAsync(customer.Id);
                if (existingCustomer != null)
                {
                    throw new CustomerAlreadyExistsException($"Customer with id {customer.Id} already exists.");
                }
                await _customerRepository.AddAsync(customer);
            }
            catch (CustomerAlreadyExistsException ex)
            {
                throw; // Re-throw the custom exception as is
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error adding customer", ex);
            }
        }

        public async Task UpdateAsync(Customer customer)
        {
            try
            {
                await _customerRepository.UpdateAsync(customer);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error updating customer", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _customerRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException($"Error deleting customer with id: {id}", ex);
            }
        }
    }
}
