using System.Text.Json.Serialization;

namespace BarberFusion.Domain.Entities
{
    public class Shop
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Customer> Customers { get; set; } 
        [JsonIgnore]
        public List<Service> Services { get; set; }
        [JsonIgnore]
        public List<Appointment> Appointments { get; set; }
        [JsonIgnore]
        public List<Invoice> Invoices { get; set; } 
        [JsonIgnore]
        public List<User> Users { get; set; } 
        [JsonIgnore]
        public List<Role> Roles { get; set; } 
    }
}
