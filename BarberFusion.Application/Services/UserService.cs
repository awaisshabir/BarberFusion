using BarberFusion.Application.Interfaces.Repositories;
using BarberFusion.Application.Interfaces.Services;
using BarberFusion.Domain.Entities;

namespace BarberFusion.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            try
            {
                return await _userRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException($"Error getting user by id: {id}", ex);
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return await _userRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error getting all users", ex);
            }
        }

        public async Task AddAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error adding user", ex);
            }
        }

        public async Task UpdateAsync(User user)
        {
            try
            {
                await _userRepository.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error updating user", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _userRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException($"Error deleting user with id: {id}", ex);
            }
        }
    }
}
