using BarberFusion.Application.Interfaces.Repositories;
using BarberFusion.Application.Interfaces.Services;
using BarberFusion.Domain.Entities;

namespace BarberFusion.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> GetByIdAsync(Guid id)
        {
            try
            {
                return await _roleRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException($"Error getting role by id: {id}", ex);
            }
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            try
            {
                return await _roleRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error getting all roles", ex);
            }
        }

        public async Task AddAsync(Role role)
        {
            try
            {
                await _roleRepository.AddAsync(role);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error adding role", ex);
            }
        }

        public async Task UpdateAsync(Role role)
        {
            try
            {
                await _roleRepository.UpdateAsync(role);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error updating role", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _roleRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException($"Error deleting role with id: {id}", ex);
            }
        }
    }
}
