namespace BarberFusion.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
