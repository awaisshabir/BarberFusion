using BarberFusion.Domain.Entities;

namespace BarberFusion.Application.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<Appointment> GetByIdAsync(Guid id);
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(Guid id);
    }
}
