using BarberFusion.Application.Interfaces.Repositories;
using BarberFusion.Application.Interfaces.Services;
using BarberFusion.Domain.Entities;

namespace BarberFusion.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            try
            {
                return await _appointmentRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException($"Error getting appointment by id: {id}", ex);
            }
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            try
            {
                return await _appointmentRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error getting all appointments", ex);
            }
        }

        public async Task AddAsync(Appointment appointment)
        {
            try
            {
                await _appointmentRepository.AddAsync(appointment);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error adding appointment", ex);
            }
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            try
            {
                await _appointmentRepository.UpdateAsync(appointment);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error updating appointment", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _appointmentRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException($"Error deleting appointment with id: {id}", ex);
            }
        }
    }
}
